using DDD.Domain;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"
                            SELECT  AreaId,
                                    AreaName
                            FROM    Areas
                                        ";

            //return SQLiteHelper.Query<AreaEntity>(sql, CreateEntity);

            return SQLiteHelper.Query<AreaEntity>(sql,
                reader => 
                {
                    return new AreaEntity(Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]));
                });

            //var result = new List<AreaEntity>();

            //using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            //using (var command = new SQLiteCommand(sql, connection))
            //{
            //    connection.Open();

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            result.Add(
            //                new AreaEntity(Convert.ToInt32(reader["AreaId"]),
            //                Convert.ToString(reader["AreaName"]))
            //                );
            //        }
            //    }
            //    return result.AsReadOnly();

            //}
        }

        //private AreaEntity CreateEntity(SQLiteDataReader reader) 
        //{
        //    return new AreaEntity(Convert.ToInt32(reader["AreaId"]),
        //                    Convert.ToString(reader["AreaName"]));
        //}
    }
}
