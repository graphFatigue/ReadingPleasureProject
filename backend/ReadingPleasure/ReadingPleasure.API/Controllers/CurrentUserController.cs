using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Application;
using ReadingPleasure.Common.Constants;

namespace ReadingPleasure.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route(Constants.ApiEndpoints.CurrentUser.Base)]
    public class CurrentUserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IContextAccessor _contextAccessor;

        public CurrentUserController(
            IUserService userService,
            IContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet(Constants.ApiEndpoints.CurrentUser.Info)]
        public async Task<IActionResult> GetInfo(CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(_contextAccessor.GetCurrentUserId(), cancellationToken);
            return Ok(user);
        }
    }
}
