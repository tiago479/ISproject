using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SOMOID.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMOID.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly ISomoidHttpClient somoidHttpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISomoidHttpClient somoidHttpClient)
        {
            this.logger = logger;
            this.somoidHttpClient=somoidHttpClient;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            //somoidHttpClient.Ping(); //posso tambem faazer a mesma logica com basedados ....
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
