using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostPlusOperation")]
        public int Post(int a, int b)
        {
            return a + b;
        }

        // Regrese un elemento del arreglo por posicion
        [HttpPost(Name = "PostPositionArray")]
        public string Post(int a)
        {
            if (a > Summaries.Length)
            {
                var message = string.Format("Product with index = {0} not found", a);
                return new String(message.ToArray());
            }
            else
            {
                return new String(Summaries[a].ToArray());
            }
        }



        // Agregar un elemento al arreglo y regresar todos
    }
}