// <copyright file="WeatherControllerSettings.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using HelloWorldWebMVC.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration conf)
        {
            this.ApiKey = conf["WeatherForecast:ApiKey"];
            this.Latitude = conf["WeatherForecast:Latitude"];
            this.Longitude = conf["WeatherForecast:Longitude"];
        }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string ApiKey { get; set; }
    }
}