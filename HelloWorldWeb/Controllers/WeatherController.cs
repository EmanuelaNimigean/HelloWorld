// <copyright file="WeatherController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorldWweb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWebApp.Controllers
{
    /// <summary>
    /// fetch data from weather API
    /// <see href="https://openweathermap.org/api">
    /// Weather API
    /// </see>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public const double KELVINCONST = 273.15;
        private readonly string latitude;
        private readonly string longitude;
        private readonly string apiKey;

        public WeatherController(IWeatherControllerSettings weatherControllerSettings)
        {
            this.longitude = weatherControllerSettings.Longitude;
            this.latitude = weatherControllerSettings.Latitude;
            this.apiKey = weatherControllerSettings.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // lat 46.7700 lon 23.5800
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=bfe996606177703436b8ea1351e2bf09
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={this.latitude}&lon={this.longitude}&exclude=hourly,minutely&appid={this.apiKey}")
            {
                Timeout = -1,
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return this.ConvertResponseToWeatherRecordList(response.Content);
        }

        [NonAction]
        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            if (json["daily"] == null)
            {
                throw new Exception("Api key is not valid.");
            }

            var jsonArray = json["daily"].Take(7);
            return jsonArray.Select(this.CreateDailyWeatherRecordFromJToken);
        }

        /// <summary>
        /// Get a weather forecast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="index">Amount of days from now (from 0 to 7).</param>
        /// <returns>The weather forecast.</returns>
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return "value";
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
            var temperature = (decimal)(item.SelectToken("temp").Value<float>("day") - KELVINCONST);
            var type = this.Convert(item.SelectToken("weather")[0].Value<string>("description"));

            DailyWeatherRecord dailyWeatherRecord = new (day, temperature, type);
            return dailyWeatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "freezing":
                    return WeatherType.Freezing;
                case "bracing":
                    return WeatherType.Bracing;
                case "chilly":
                    return WeatherType.Chilly;
                case "cool":
                    return WeatherType.Cool;
                case "mild":
                    return WeatherType.Mild;
                case "balmy":
                    return WeatherType.Balmy;
                case "hot":
                    return WeatherType.Hot;
                case "sweltering":
                    return WeatherType.Sweltering;
                case "scorching":
                    return WeatherType.Scorching;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                case "few clouds":
                    return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "clear sky":
                    return WeatherType.ClearSky;
                case "overcast clouds":
                    return WeatherType.OvercastClouds;
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }
    }
}