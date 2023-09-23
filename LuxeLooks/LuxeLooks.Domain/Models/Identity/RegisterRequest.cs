using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Models.Identity;

public class RegisterRequest
{
    [Required] 
    [Display(Name = "Email")] 
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Имя")]
    public string UserName { get; set; } = null!;
    
}