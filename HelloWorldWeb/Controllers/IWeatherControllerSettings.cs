// <copyright file="IWeatherControllerSettings.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWebApp.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { get; set; }

        string Latitude { get; set; }

        string ApiKey { get; set; }
    }
}