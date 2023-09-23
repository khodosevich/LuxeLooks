using Microsoft.AspNetCore.Identity;

namespace LuxeLooks.Domain.Entity;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string NormalizedUserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Guid RoleId { get; set; } = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe");
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public string PasswordSalt { get; set; }

}