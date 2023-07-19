using KANOKO.Auth;
using KANOKO.Dto;
using KANOKO.Interface.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EscrowService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthentication _jwtauth;

        public AuthController(IUserService userService, IJWTAuthentication jwtauth)
        {
            _userService = userService;
            _jwtauth = jwtauth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest _request)
        {
            var login = await _userService.Login(_request);
            if (login.IsSuccess == false)
            {
                return BadRequest(login);
            }

            var response = new UserLoginResponse()
            {
                Email = login.Data.Email,
                Token = _jwtauth.GenerateToken(login.Data),
                Data = login.Data,
                Status = true,
                Message = login.Message
            };
            return Ok(response);
        }


        [Authorize] // Requires authentication to access this endpoint
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            // Get the user's email from the claims
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            // Retrieve the user data based on the email (assuming you have a service method to do this)
            var user = await _userService.GetUserByEmail(userEmail);

            if (user == null)
            {
                return NotFound(); // Return 404 if the user is not found
            }

            // Create a UserDto object with the user data
            var userDto = new UserDto
            {
                Role = user.Role,
                Email = user.Email,
                Address= user.Address,
                FirstName= user.FirstName,
                LastName= user.LastName,
                PhoneNumber = user.PhoneNumber 
                
                // Add other properties as needed
            };

            return Ok(userDto);
        }

    }
}