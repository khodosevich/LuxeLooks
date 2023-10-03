using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Enum;

public enum ProductType
{
    [Display(Name = "Jacket")] Jacket,
    [Display(Name = "Sneakers")] Sneakers,
    [Display(Name = "Shoes")] Shoes,
    [Display(Name = "Cap")] Cap,
    [Display(Name = "TShirt")] TShirt,
    [Display(Name = "Hoodie")] Hoodie,
    [Display(Name = "Longsleeve")] Longsleeve,
    [Display(Name = "Shorts")] Shorts,
    [Display(Name = "Shirt")] Shirt,
    [Display(Name = "Socks")] Socks,
    [Display(Name = "Flipflops")] Flipflops,
    [Display(Name = "Trousers")] Trousers,
    [Display(Name = "Underpants")] Underpants,
    [Display(Name = "Dress")] Dress,
    [Display(Name = "Hat")] Hat,
    [Display(Name = "Skirt")] Skirt
}