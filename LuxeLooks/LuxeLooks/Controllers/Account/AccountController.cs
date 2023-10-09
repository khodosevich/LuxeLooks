using System.IdentityModel.Tokens.Jwt;
using System.Net;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Models.Identity;
using LuxeLooks.Service.Extensions;
using LuxeLooks.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.Account;

[ApiController]
[Route("Account")]
public class AccountController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly UserService _userService;
    private readonly ILogger<AccountController>_logger;

    public AccountController(TokenService tokenService, IConfiguration configuration, UserService userService, ILogger<AccountController> logger)
    {
        _tokenService = tokenService;
        _configuration = configuration;
        _userService = userService;
        _logger = logger;
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUserResponse = await _userService.FindByNameAsync(request.UserName);
        
        if (managedUserResponse.StatusCode!=HttpStatusCode.OK)
        {
            _logger.LogError(managedUserResponse.Description);
            return BadRequest("Bad credentials");
        }

        var managedUser = managedUserResponse.Data;
        var isPasswordValidResponse = await _userService.CheckPasswordAsync(managedUser, request.Password);
        
        if (isPasswordValidResponse.StatusCode!=HttpStatusCode.OK)
        {
            _logger.LogError(isPasswordValidResponse.Description);
            return BadRequest("Bad credentials");
        }

        var userResponse = await _userService.FindByNameAsync(request.UserName);
        
        if (userResponse.StatusCode!= HttpStatusCode.OK)
            return Unauthorized();

        var user = userResponse.Data;
        var accessToken =await _tokenService.CreateToken(user);
        user.RefreshToken = _configuration.GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:TokenValidityInDays").Get<int>());
        await _userService.UpdateAsync(user);
        _logger.LogInformation($"Successfuly login user: {user.UserName}");
        HttpContext.Response.Cookies.Append("refreshToken", user.RefreshToken, new CookieOptions
        {
            HttpOnly = true, 
            Secure = false, 
            SameSite = SameSiteMode.None, 
            Expires = DateTime.UtcNow.AddMonths(1) 
        });
        return Ok(new AuthResponse
        {
            Username = user.UserName!,
            Email = user.Email!,
            Token = accessToken
        });
    }
    
    [HttpPost("Register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(request);
        var user = new User()
        {
            Email = request.Email,
            UserName = request.UserName,
        };
        var findUser = await _userService.FindByNameAsync(request.UserName);
        if (findUser.Data!=null)
        {
            return BadRequest($"Use with {request.UserName} is exist");
        }
        var result = await _userService.CreateAsync(user, request.Password);

        if (result.StatusCode!=HttpStatusCode.OK) return BadRequest(ModelState.Values);

        var findUserResponse = await _userService.FindByNameAsync(request.UserName);

        if (findUserResponse.StatusCode != HttpStatusCode.OK) throw new Exception($"User {request.UserName} not found");
        await _userService.AddToRoleAsync(findUserResponse.Data.Id, "Resident");
        _logger.LogInformation($"Successfuly register user: {findUserResponse.Data.UserName}");
        return await Authenticate(new AuthRequest
        {
            UserName = request.UserName,
            Password = request.Password
        });
    }
    
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
    {
        if (tokenModel is null || string.IsNullOrEmpty(tokenModel.AccessToken))
        {
            return BadRequest("Invalid client request");
        }

        var accessToken = tokenModel.AccessToken;
        var refreshToken = tokenModel.RefreshToken;
        var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);
        
        if (principal == null)
        {
            return BadRequest("Invalid access token or refresh token");
        }
        
        var username = principal.Identity!.Name;
        var userResponse = await _userService.FindByNameAsync(username!);
        if (userResponse.StatusCode!=HttpStatusCode.OK)
        {
            return BadRequest();
        }

        var user = userResponse.Data;
        var userRefreshToken = user.RefreshToken;
        if ( userRefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return BadRequest("Invalid access token or refresh token");
        }

        var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
        await _userService.UpdateAsync(user);

        return new ObjectResult(new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        });
    }
    
    [Authorize]
    [HttpPost]
    [Route("Revoke/{username}")]
    public async Task<IActionResult> Revoke(string username)
    {
        var response = await _userService.FindByNameAsync(username);
        if (response.StatusCode!=HttpStatusCode.OK) return BadRequest("Invalid user name");
        var user = response.Data;
        user.RefreshToken = null;
        await _userService.UpdateAsync(user);
        HttpContext.Response.Cookies.Delete("refreshToken");

        return Ok();
    }
    
    [Authorize]
    [HttpPost("RevokeAll")]
    public async Task<IActionResult> RevokeAll()
    {
        var response =await _userService.GetAllAsync();
        if (response.StatusCode!=HttpStatusCode.OK)
        {
            return NoContent();
        }

        var users = response.Data;
        foreach (var user in users)
        {
            user.RefreshToken = null;
            await _userService.UpdateAsync(user);
        }

        return Ok();
    }
}