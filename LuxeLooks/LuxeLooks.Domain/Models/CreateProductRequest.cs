namespace LuxeLooks.Domain.Models;

public class CreateProductRequest
{
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsForMen { get; set; }
    public bool IsForKids { get; set; }
}