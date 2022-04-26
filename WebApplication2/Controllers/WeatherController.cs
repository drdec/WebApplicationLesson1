using System.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class WeatherController : Controller
    {
        public static Weather weather = new();

        [HttpPost("add value")]
        public IActionResult AddTemperature(DateTime time, float temperature)
        {
            weather.Add(new Weather()
            {
                Temperature = temperature,
                Time = time,
            });

            return Ok(weather);
        }

        [HttpGet("get result")]
        public IActionResult GetResult()
        {
            return Ok(weather.Get());
        }

        [HttpGet("get result after a certain date")]
        public IActionResult GetResult(DateTime time)
        {
            return Ok(weather.Get(time));
        }

        [HttpPut("update result")]
        public IActionResult Update(DateTime time, float temperature)
        {
            weather.Update(time, temperature);
            return Ok();
        }

        [HttpDelete("delete value")]
        public IActionResult Delete(DateTime time)
        {
            weather.Delete(time);
            return Ok();
        }
    }
}
