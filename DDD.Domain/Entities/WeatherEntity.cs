﻿using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entities
{
    //継承できないｸﾗｽ
    public sealed class WeatherEntity
    {
        //完全コンストラクタパターン
        //ct tab tab
        public WeatherEntity(int areaId, 
                             DateTime datedate,
                             int conditon,
                             float temperature
            )
        {
            AreaId = areaId;
            DataDate = datedate;
            Condition = new Condition(conditon);
            Temperature = new Temperature(temperature);
        }

        //読み取り専用のプロパティ
        public int AreaId { get; }
        public DateTime DataDate { get;  }
        public Condition Condition { get;  }
        public Temperature Temperature { get;  }

        public bool IsMousho() 
        {
            if (Condition == Condition.Sunny) 
            {
                if (Temperature.Value > 30) 
                {
                    return true;
                }
            }
            return false;
        }

    }

    

}
