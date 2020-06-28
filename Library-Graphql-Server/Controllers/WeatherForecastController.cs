using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Server.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public List<Borrows> Get()
        {
            var borrowed = new List<Borrows>();
            using (var Library = new libraryContext())
            {
                borrowed = Library.Borrows.Select(x => x).ToList();
            }
            return borrowed;
        }
    }
}
