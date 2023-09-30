using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Enum;

public enum ProductType
{
    [Display(Name = "Куртка")] Jacket,
    [Display(Name = "Кроссовки")] Sneakers,
    [Display(Name = "Туфли")] Shoes,
    [Display(Name = "Кепка")] Cap,
    [Display(Name = "Майка")] TShirt,
    [Display(Name = "Худи")] Hoodie,
    [Display(Name = "Лонгслив")] Longsleeve,
    [Display(Name = "Рубашка")] Shirt,
    [Display(Name = "Носки")] Socks,
    [Display(Name = "Шлепки")] Flipflops,
    [Display(Name = "Штаны")] Trousers,
    [Display(Name = "Трусы")] Underpants,
    [Display(Name = "Платье")] Dress,
    [Display(Name = "Шапка")] Hat,
    [Display(Name = "Юбка")] Skirt
}