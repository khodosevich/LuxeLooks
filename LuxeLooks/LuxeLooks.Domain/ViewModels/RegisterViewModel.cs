using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.ViewModels;

public class RegisterViewModel
{
    [Required]
    [Display(Name = "Логин")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Пароль")]
    [MinLength(5,ErrorMessage = "Слишком короткий пароль : Минимальная длина 5 букв")]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

}