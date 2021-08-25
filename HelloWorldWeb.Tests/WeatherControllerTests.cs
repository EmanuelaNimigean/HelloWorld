// <copyright file="WeatherControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using HelloWorldWebApp.Controllers;
    using HelloWorldWweb.Models;
    using Moq;
    using Xunit;

    public class WeatherControllerTests
    {
        private Mock<IWeatherControllerSettings> weatherControllerSettingsMock;

        [Fact]
        public void TestMethodForCheckingConversion()
        {
            // Assume
            this.weatherControllerSettingsMock = new Mock<IWeatherControllerSettings>();
            string content = this.LoadJsonFromResource();
            WeatherController weatherController = new WeatherController(this.weatherControllerSettingsMock.Object);

            // Act
            var result = weatherController.ConvertResponseToWeatherRecordList(content);

            // Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();
            decimal temperature = Math.Round(firstDay.Temperature, 2);

            Assert.Equal(new DateTime(2021, 08, 12), firstDay.Day);

            // Assert.Equal((decimal)272.88, firstDay.Temperature);// kelvin check
            Assert.Equal(24.73M, temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.TestData.ContentWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
