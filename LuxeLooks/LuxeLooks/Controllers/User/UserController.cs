using System.Net;
using LuxeLooks.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.User;
[Route("User")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetByid/{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var userResponse = await _userService.GetByIdAsync(id);
        if (userResponse.StatusCode!=HttpStatusCode.OK)
        {
            return BadRequest(userResponse.Description);
        }

        return Ok(userResponse.Data);
    }
}