using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.Auth;

namespace ReadingPleasure.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route(Constants.ApiEndpoints.Auth.Base)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
           IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost(Constants.ApiEndpoints.Auth.Login)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var jwtTokenResponse = await _authService.LoginAsync(loginDto);
            return Ok(jwtTokenResponse);
        }

        [AllowAnonymous]
        [HttpPost(Constants.ApiEndpoints.Auth.Signup)]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            await _authService.SignupAsync(signupDto);
            return NoContent();
        }
    }
}
