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
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude= "46.7700";
        private readonly string longitude= "23.5800";
        private readonly string apiKey= "cc9172eeab7743b7d5cbc7d65ac03925";

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);
        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();
            var jsonArray = json["daily"].Take(7);
            foreach (var item in jsonArray)
            {
                //TODO: Convert item to DailyWeatherRecord
                DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(new DateTime(2021, 8, 12), 22.0f, WeatherType.Mild);

                long unixDateTime = item.Value<long>("dt");
                var temperature = item.SelectToken("temp");
                string weather = item.SelectToken("weather")[0].Value<string>("description");

                dailyWeatherRecord.Day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
                dailyWeatherRecord.Temperature = DailyWeatherRecord.kelvinToCelsius(temperature.Value<float>("day"));
                dailyWeatherRecord.Type = Convert(weather);

                result.Add(dailyWeatherRecord);
            }
            return result;
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
                default:
                    throw new Exception($"Unknown weather type {weather}!");
            }
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
