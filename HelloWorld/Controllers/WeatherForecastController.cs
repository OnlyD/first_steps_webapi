using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<string> SummariesList = new List<string>()
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
        [HttpGet("Position")]
        public string Post(int a)
        {
            var position = "";
            try
            {
                position = Summaries[a];
            }
            catch
            {
                return "error";
            }

            return position;
        }
        //int
        //float
        //objeto
        [HttpGet("Search")]
        public string? GetSearch(string summary)
        {
            return Summaries.FirstOrDefault(x => x.Contains(summary));
        }

        [HttpGet("search-list")]
        public IEnumerable<string> GetList(string summary)
        {
            return Summaries.Where(x => x.Contains(summary));
        }

        [HttpPost("summaryArray")]
        public IEnumerable<string> NewSummary([FromBody] string summary)
        {
            return Summaries.Append(summary).ToArray();
        }

        [HttpPost("summaryList")]
        public IEnumerable<string> NewSummaryList([FromBody] string summary)
        {
            return SummariesList.Append(summary).ToList();
        }

        [HttpGet("summaryList")]
        public int CountSummariesList()
        {
            return Summaries.Count();
        }

        [HttpGet("summaryListlenght")]
        public int LenghtSummariesList()
        {
            return Summaries.Length;
        }

        // Agregar un elemento al arreglo y regresar todos
        // Hacer las busquedas -> Linq case ignore
        // Hacer un request de cada verbo Http
    }
}