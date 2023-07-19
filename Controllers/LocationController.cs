using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KANOKO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController: ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocationController (ILocationService locationService, IWebHostEnvironment webHostEnvironment)
        {
            _locationService = locationService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateLocationRequestModel model)
        {
            var location = await _locationService.CreateLocation(model);
            if (location == null)
            {
                return BadRequest(location.Message);
            }
            return Ok(location);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var location = await _locationService.GetLocationAsync(id);
            if (location == null)
            {
                return BadRequest(location.Message);
            }
            return Ok(location);
        }

        /*[HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationRequestModel model)
        {
            var get = Location.FindFirst(ClaimTypes.Name).Value;
        }*/

    }
}
