using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SOMOID.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        //[HttpGet("Ping/oisdgj/{cenas}")] assim tem duas hierarquias
        //public IActionResult GetPing(string cenas)
        //{
        //    return Ok();
        //}

        //[HttpPost("Ping/{cenas}")]
        //public IActionResult GetPing([FromBody] WeatherForecast cenasBody, string cenas)
        //{
        //    return Ok();
        //}

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
