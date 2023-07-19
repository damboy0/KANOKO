using KANOKO.Dto;
using KANOKO.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace KANOKO.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAdminService adminService, IWebHostEnvironment webHostEnvironment)
        {
            _adminService = adminService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateAdminRequestModel model)
        {
            var admin = await _adminService.CreateAdminAsync(model);
            if (admin == null)
            {
                return BadRequest(admin.Message);
            }
            return Ok(admin);
        }

       
    }
}
