using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.ViewModels;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Логин")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Display(Name = "Запомнить меня?")]
    public bool RememberMe { get; set; }
    
}