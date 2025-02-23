using MacSolutions.Application.Alarms.Queries.GetZone;
using MacSolutions.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacSolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantPerformanceController(PerformanceZoneService _performanceZoneService) : ControllerBase
    {
        [HttpPost("determinezone")]
        public IActionResult DetermineZone([FromQuery] double averageAlarmRate, [FromQuery] double percentageOutsideTarget)
        //public IActionResult DetermineZone(GetZoneByAlarmRateAndOutsideTarget performanceDatra)
        {
            if (averageAlarmRate < 0 || averageAlarmRate > 100
                || percentageOutsideTarget < 0 || percentageOutsideTarget > 50)
            {
                return BadRequest("Invalid input data.");
            }

            var zone = _performanceZoneService.DetermineZone(new GetZoneByAlarmRateAndOutsideTarget(averageAlarmRate, percentageOutsideTarget));
            return Ok(new { Zone = zone.ToString() });
        }
    }
}
