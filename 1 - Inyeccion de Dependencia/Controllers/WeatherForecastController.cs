using System;
using System.Collections.Generic;
using System.Linq;
using _1___Inyeccion_de_Dependencia.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _1___Inyeccion_de_Dependencia.Controllers
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
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMiInterface miInterface, IMiInterfaceGenerica<WeatherForecastController> miInterfaceGenerica) //<--Pido las inyecciones
        {
            _logger = logger;
            _miInterface = miInterface; //<-- Las encapsulamos para usar en la clase.
            _miInterfaceGenerica = miInterfaceGenerica;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
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
