using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Models.Identity;

public class RegisterRequest
{
    [Required] 
    [EmailAddress]
    [Display(Name = "Email")] 
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(5)]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    [Required]
    [MinLength(5)]
    [Display(Name = "Имя")]
    public string UserName { get; set; } = null!;
    
}