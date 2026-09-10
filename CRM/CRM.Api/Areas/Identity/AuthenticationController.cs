
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
        public async Task<IActionResult> Login([FromBody] ApplicationUserLoginInputModel model)
        {
            var response = await _authenticationService.LoginAsync(model);
              return response ? Ok(response) : StatusCode(500);
        }

        [HttpPost("register")]
        [DisplayName("Register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserRegisterInputModel model)
        {
            var response = await _authenticationService.RegisterAsync(model);
            return response ? Ok(response) : StatusCode(500);
        }

        [HttpPost("forgot-password")]
        [DisplayName("forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ApplicationUserLoginInputModel model)
        {
            var response = await _authenticationService.ForgotPasswordAsync(model);
              return response ? Ok(response) : StatusCode(500);
        }

        [HttpPost("reset-password")]
        [DisplayName("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ApplicationUserRegisterInputModel model)
        {
            var response = await _authenticationService.ResetPasswordAsync(model);
              return response ? Ok(response) : StatusCode(500);
        }
    }
}
