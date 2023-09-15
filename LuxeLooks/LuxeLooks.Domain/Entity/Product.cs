using LuxeLooks.Domain.Enum;

namespace LuxeLooks.Domain.Entity;

public class Product
{
    public int? Id { get; set; }
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ProductType Type { get; set; }
    public string? ImageUrl { get; set; }
}