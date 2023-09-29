using System.IdentityModel.Tokens.Jwt;
using LuxeLooks.Domain.Entity;
using Microsoft.Extensions.Configuration;
using static LuxeLooks.Service.Extensions.JwtTokenExtension;

namespace LuxeLooks.Service.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;
    private readonly RoleService _roleService;

    public TokenService(IConfiguration configuration, RoleService roleService)
    {
        _configuration = configuration;
        _roleService = roleService;
    }


    public async Task<string> CreateToken(User user)
    {
        var role = (await _roleService.GetByIdAsync(user.RoleId)).Data;
        JwtSecurityToken token = user
            .CreateClaims(new List<Role>(){role})
            .CreateJwtToken(_configuration);
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}