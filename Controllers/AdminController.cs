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
        [HttpGet("Create")]
        public async Task<IActionResult> Create([FromForm] AdminRequestModel model)
        {
            var admin = await _adminService.RegisterAdmin(model);
            if (admin.Status == false)
            {
                return BadRequest(admin.Message);
            }
            return Ok(admin);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var admin = await _adminService.GetAllAdmins();
            if (admin.Status == false)
            {
                return BadRequest(admin.Message);
            }
            return Ok(admin);
        }
    }
}
