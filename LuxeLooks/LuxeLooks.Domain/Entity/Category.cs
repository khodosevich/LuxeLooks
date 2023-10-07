using System.Net.Mime;
using LuxeLooks.Domain.Enum;

namespace LuxeLooks.Domain.Entity;

public class Category
{
    public Guid Id { get; set; }
    public ProductType ProductType { get; set; }
    public string ImageUrl { get; set; }
}