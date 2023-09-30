using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Enum;

public enum OrderStatus
{
    [Display(Name = "В обработке")] Processing = 0,
    [Display(Name = "Отправлен")] Sent = 1,
    [Display(Name = "Завершен")] Completed = 2
}