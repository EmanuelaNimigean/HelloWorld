﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebMVC.Models
{
    public class DailyWeatherRecord
    {

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Day { get; set; }


        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            this.Day = day;
            this.Temperature = temperature;
            this.Type = type;
        }

        public DailyWeatherRecord()
        {
        }

        public static float KelvinToCelsius(float temp)
        {
            return (float)(temp - 273.15);
        }
    }

}
