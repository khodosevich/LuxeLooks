using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Models.Identity;

public class AuthRequest
{
    [MinLength(4)]
    public string UserName { get; set; } = null!;
    [MinLength(5)]
    public string Password { get; set; } = null!;
}