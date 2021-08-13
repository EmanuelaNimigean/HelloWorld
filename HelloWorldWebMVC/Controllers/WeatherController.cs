using HelloWorldWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWebMVC.Controllers
{
    /// <summary>
    /// fetch data from weather API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude = "46.7700";
        private readonly string longitude = "23.5800";
        private readonly string apiKey = "cc9172eeab7743b7d5cbc7d65ac03925";

        public WeatherController(IWeatherControllerSettings settings)
        {
            this.longitude = settings.Longitude;
            this.latitude = settings.Latitude;
            this.apiKey = settings.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={this.latitude}&lon={this.longitude}&exclude=hourly,minutely&appid={this.apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return this.ConvertResponseToWeatherRecordList(response.Content);
        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            var jsonArray = json["daily"].Take(7);
            return jsonArray.Select(this.ConvertDailyWeatherFromJToken);
        }

        private DailyWeatherRecord ConvertDailyWeatherFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var temperature = item.SelectToken("temp");
            string weather = item.SelectToken("weather")[0].Value<string>("description");

            DateTime formatDateTime = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
            float formatTemperature = DailyWeatherRecord.KelvinToCelsius(temperature.Value<float>("day"));
            WeatherType formatType = this.Convert(weather);

            DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(formatDateTime, formatTemperature, formatType);
            return dailyWeatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds":
                    return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "scattered clouds":
                    return WeatherType.ScatteredClouds;
                case "clear sky":
                    return WeatherType.ClearSky;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                default:
                    throw new Exception($"Unknown weather type {weather}!");
            }
        }
     }
}
