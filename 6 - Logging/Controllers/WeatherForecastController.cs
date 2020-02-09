using System;
using System.Collections.Generic;
using System.Linq;
using _6___Logging.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _6___Logging.Controllers
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
            //Tenemos distintos niveles de logs, los cuales podemos utilizar en cualquier momento, y segun la configuracion que le damos es el que vaos a ver.
            // el orden de importancia de menor a mayor es:
            _logger.LogTrace(""); //Si la configuracion esta en trace veremos como loguea desde trace hasta critical
            _logger.LogDebug("");
            _logger.LogInformation("");
            _logger.LogWarning(""); //si la configuracion esta en Warning veremos como loguea de warning hasta critical ignorando los niveles inderiores.
            _logger.LogError("");
            _logger.LogCritical("");

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
