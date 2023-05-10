using Microsoft.AspNetCore.Mvc;
using SunriseSunsetAPI.Core.Interfaces;
using SunriseSunsetAPI.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SunriseSunsetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunriseSunsetController : ControllerBase
    {
        public readonly ISunriseSunsetAPI _sunriseSunsetAPI;
        public SunriseSunsetController(ISunriseSunsetAPI sunriseSunsetAPI)
        {
            _sunriseSunsetAPI = sunriseSunsetAPI;
        }

        // GET api/<SunriseSunsetController>/5
        [HttpPost]
        public IActionResult GetSunrise([FromBody] SunriseSunsetRequestDTO sunriseSunsetRequestDTO)
        {
            var sunriseSunsetDTO = _sunriseSunsetAPI.GetSunriseSunsetAsync(sunriseSunsetRequestDTO.Latitude, sunriseSunsetRequestDTO.Longitude, sunriseSunsetRequestDTO.Date);
            return new ObjectResult(sunriseSunsetDTO);
        }

    }
}
