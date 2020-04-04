using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.WinForm.Common;
using System.Data.SQLite;
using System.Data;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;

namespace DDD.Infrastructure.Data
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId) 
        {
            string sql = @"
                SELECT  DataDate,
                        Condition,
                        Temperatrure
                FROM Weather
                WHERE AreaId = @AreaId
                ORDER BY DataDate DESC
                LIMIT 1
            ";

            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId", areaId)
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperatrure"]));
                },
                null);


            //using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            //using (var command = new SQLiteCommand(sql, connection))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@AreaId", areaId);
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            return new WeatherEntity(
            //                areaId,
            //                Convert.ToDateTime(reader["DataDate"]),
            //                Convert.ToInt32(reader["Condition"]),
            //                Convert.ToSingle(reader["Temperatrure"]));
            //        }
            //    }
            //    return null;

            //}
        }

        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
select 
    A.AreaId,
    ifnull(B.AreaName,'') as AreaName,
    A.DataDate,
    A.Condition,
    A.Temperatrure
from Weather A
left outer join Areas B
on A.AreaId = B.AreaId
";
            return SQLiteHelper.Query(sql,
                reader => 
                {
                    return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperatrure"])); ;
                }
                );
        }

        public void Save(WeatherEntity weather)
        {
            string insert = @"
insert into Weather
(AreaId, DataDate, Condition, Temperatrure)
values
(@AreaId, @DataDate, @Condition, @Temperatrure)
";
            string update = @"
update Weather
set Condition = @Condition,
    Temperatrure = @Temperatrure
where AreaId = @AreaId
and DataDate = @DataDate
";

            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@AreaId", weather.AreaId.Value),
                new SQLiteParameter("@DataDate", weather.DataDate),
                new SQLiteParameter("@Condition", weather.Condition.Value),
                new SQLiteParameter("@Temperatrure", weather.Temperature.Value),
            };

            SQLiteHelper.Execute(insert, update, args.ToArray());

        }
    }
}
