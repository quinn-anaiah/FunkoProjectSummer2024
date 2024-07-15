// Location: MyApi/Controllers/Weather/WeatherForecastController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast(
            
                Date: DateTime.Now.AddDays(index),
                TemperatureC: rng.Next(-20, 55),
                Summary: Summaries[rng.Next(Summaries.Length)]
            ))
            .ToArray();
        }

        public record WeatherForecast(DateTime Date, int TemperatureC, string Summary);

        // Additional methods, if any
    }
}
