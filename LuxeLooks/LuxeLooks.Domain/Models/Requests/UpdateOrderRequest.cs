using System.ComponentModel.DataAnnotations;
using LuxeLooks.Domain.Enum;

namespace LuxeLooks.Domain.Models.Requests;

public class UpdateOrderRequest
{
    public string Id { get; set; }
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Address { get; set; }
    public List<string> ProductsIds { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
}