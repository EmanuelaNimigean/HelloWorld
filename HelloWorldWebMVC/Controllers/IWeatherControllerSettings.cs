﻿namespace HelloWorldWebMVC.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { get; }

        string Latitude { get; }

        string ApiKey { get; }
    }
}