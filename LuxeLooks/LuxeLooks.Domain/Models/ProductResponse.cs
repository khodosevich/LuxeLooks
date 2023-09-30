using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Extensions;

namespace LuxeLooks.Domain.Models;

public class ProductResponse
{
    public Guid Id { get; set; }
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsForMen { get; set; }
    public bool IsForKids { get; set; }

    public ProductResponse(Product product)
    {
        Id = product.Id;
        Price = product.Price;
        Name = product.Name;
        Description = product.Description;
        ImageUrl = product.ImageUrl;
        Type = product.Type.DisplayName();
        IsForKids = product.IsForKids;
        IsForMen = product.IsForMen;
    }

    public ProductResponse()
    {
    }
}