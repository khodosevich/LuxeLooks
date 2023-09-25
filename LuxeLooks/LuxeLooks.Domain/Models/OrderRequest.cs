using System.ComponentModel.DataAnnotations;
using LuxeLooks.Domain.Enum;

namespace LuxeLooks.Domain.Models;

public class OrderRequest
{
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Address { get; set; }
    public List<Guid> ProductsIds { get; set; }
    public decimal Price { get; set; }
    public OrderStatus Status { get; set; }
    public Guid UserId { get; set; }
}