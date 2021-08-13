// <copyright file="Startup.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using HelloWorldWebMVC.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWebMVC
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration configuration)
        {
            this.ApiKey = configuration["WeatherForecast:ApiKey"];
            this.Longitude = configuration["WeatherForecast:Longitude"];
            this.Latitude = configuration["WeatherForecast:Latitude"];
        }

        public WeatherControllerSettings()
        {
        }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string ApiKey { get; set; }
    }
}