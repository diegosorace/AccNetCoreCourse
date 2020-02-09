using System;
using System.Collections.Generic;
using System.Linq;
using _5___Swagger_y_Postman.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _5___Swagger_y_Postman.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMiInterface _miInterface;
        private readonly IMiInterfaceGenerica<WeatherForecastController> _miInterfaceGenerica;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMiInterface miInterface, IMiInterfaceGenerica<WeatherForecastController> miInterfaceGenerica, IConfiguration configuration)
        {
            _logger = logger;
            _miInterface = miInterface;
            _miInterfaceGenerica = miInterfaceGenerica;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var value = _configuration["Configuracion"];

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public bool Post(string value)
        {
            var result = _configuration["Configuracion"];

            return true;
        }

        [HttpPut]
        public void Put(int value)
        {
            var result = _configuration["Configuracion"];

        }

        [HttpDelete]
        public void Delete(bool value)
        {
            var result = _configuration["Configuracion"];

        }
    }

}
