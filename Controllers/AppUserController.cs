using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Implemantation.Service;
using KANOKO.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KANOKO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController: ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AppUserController(IAppUserService appUserService, IWebHostEnvironment webHostEnvironment)
        {
            _appUserService = appUserService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateAppUserRequestModel model)
        {
            var appUser = await _appUserService.CreateAppUserAsync(model);
            if (appUser == null)
            { 
                return BadRequest(appUser.Message);
            }
            return Ok(appUser);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var appUser = await _appUserService.GetAppUserAsync(id);
            if (appUser == null)
            {
                return BadRequest(appUser.Message);
            }
            return Ok(appUser);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var appUser = await _appUserService.GetAllAppUserAsync();
            if (appUser == null)
            {
                return BadRequest(appUser.Message);
            }
            return Ok(appUser);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _appUserService.DeleteAppUserAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


       /* [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserRequestModel model)
        {
            var get = User.FindFirst(ClaimTypes.Name).Value;
            var result = await _appUserService.UpdateAppUserAsync(request, get);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }*/


    }
}
