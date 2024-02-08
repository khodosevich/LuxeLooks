using LuxeLooks.Domain.Enum;

namespace LuxeLooks.Domain.Models.Requests;

public class UpdateProductRequest
{
    public string Id { get; set; }
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsForMen { get; set; }
    public bool IsForKids { get; set; }
}