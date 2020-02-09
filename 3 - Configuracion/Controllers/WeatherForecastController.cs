using System;
using System.Collections.Generic;
using System.Linq;
using _3___Configuracion.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _3___Configuracion.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMiInterface miInterface, IMiInterfaceGenerica<WeatherForecastController> miInterfaceGenerica, IConfiguration configuration) // <-- Inyecto un IConfiguration 
        {
            _logger = logger;
            _miInterface = miInterface;
            _miInterfaceGenerica = miInterfaceGenerica;
            _configuration = configuration; // <-- Encapsulo la inyecion
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var value = _configuration["Configuracion"]; //<-- Lee las variables sin importar donde se encuetren.

            var rng = new Random();
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
