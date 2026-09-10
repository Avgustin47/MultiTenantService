
using CRM.Model.InputModels;
using CRM.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CRM.Api.Areas.Identity
{
    [Area("Identity")]
    [DisplayName("Authentication Controller")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        [DisplayName("Login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.LoginAsync(model);
            return Ok(response);
        }
        [HttpPost("register")]
        [DisplayName("Register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.RegisterAsync(model);
            return Ok(response);
        }
        [HttpPost("forgot-password")]
        [DisplayName("forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.ForgotPasswordAsync(model);
            return Ok(response);
        }
        [HttpPost("reset-password")]
        [DisplayName("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.ResetPasswordAsync(model);
            return Ok(response);
        }
    }
}
