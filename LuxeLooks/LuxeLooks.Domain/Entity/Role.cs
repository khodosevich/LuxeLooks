using Microsoft.AspNetCore.Identity;

namespace LuxeLooks.Domain.Entity;

public class Role 
{
    public new Guid Id { get; set; }
    public string RoleName { get; set; } = null!;
    public string NormalizedRoleName { get; set; } = null!;
}