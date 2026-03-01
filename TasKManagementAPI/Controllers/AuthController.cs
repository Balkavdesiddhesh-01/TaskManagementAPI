using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using TasKManagementAPI.DTOs;
using TasKManagementAPI.Services;

namespace TasKManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

          try
          {
                var user = await _authService.RegisterAsync(registerDto);
                return CreatedAtAction(nameof(Register), new { id = user.Id}, user);
          }
          catch(InvalidOperationException ex) 
          {
            
                return BadRequest(new {message = ex.Message});

          }
          catch(Exception ex) 
          {
                return StatusCode(500, new { message = "An error accorred during registration", detail = ex.Message });
          }
        }


    }
}
