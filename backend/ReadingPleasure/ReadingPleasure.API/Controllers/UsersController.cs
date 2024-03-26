using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Common.Constants;
using ReadingPleasure.Common.DTOs.User;

namespace ReadingPleasure.API.Controllers
{
    //[EnableCors]
    [ApiController]
    [Route(Constants.ApiEndpoints.Users.Base)]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Constants.ApiEndpoints.Users.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }

        //[HttpGet(Constants.ApiEndpoints.Users.GetAll)]
        //public async ActionResult<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken)
        //{
        //    var users = await _userService.GetAllUsersAsync(cancellationToken);
        //    return users;
        //}

        [HttpGet(Constants.ApiEndpoints.Users.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(id, cancellationToken);
            return Ok(user);
        }
    }
}
