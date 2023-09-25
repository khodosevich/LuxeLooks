using LuxeLooks.Domain.Entity;

namespace LuxeLooks.Domain.ViewModels;

public class ProductOrderViewModel
{
    public List<Product> Products { get; set; }
    public Order Order { get; set; }
}