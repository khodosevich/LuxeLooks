using LuxeLooks.Domain.Response;
using LuxeLooks.Extensions;
using LuxeLooks.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LuxeLooks.Extensions;
using LuxeLooks.Service.Extensions;

namespace LuxeLooks.Controllers.Cart;

public class CartController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<CartController> _logger;
    private readonly ProductService _productService;

    public CartController(IHttpContextAccessor httpContextAccessor, ILogger<CartController> logger, ProductService productService)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> GetCart()
    {
        List<Guid>? cart = _httpContextAccessor.HttpContext.Session.GetObject<List<Guid>>("Cart");
        if (cart != null)
        {
            BaseResponse<IEnumerable<Domain.Entity.Product>> response = await _productService.GetDevices(true);
            List<Domain.Entity.Product> products = response.Data
                .SelectMany(product =>
                    cart.Contains(product.Id)
                        ? Enumerable.Repeat(product, cart.Count(id => id == product.Id))
                        : Enumerable.Empty<Domain.Entity.Product>())
                .ToList();
            return Ok();
        }

        return Ok();
    } 
    [Authorize]
    public IActionResult AddToCart(Guid id)
    {
        List<Guid> cart = _httpContextAccessor.HttpContext.Session.GetObject<List<Guid>>("Cart") ?? new List<Guid>();
        cart.Add(id);
        _httpContextAccessor.HttpContext.Session.SetObject("Cart",cart);
        return Ok();
    }

    public IActionResult RemoveFromCart(Guid id)
    {
        List<Guid> cart = _httpContextAccessor.HttpContext.Session.GetObject<List<Guid>>("Cart") ?? new List<Guid>();
        cart.Remove(id);
        _httpContextAccessor.HttpContext.Session.SetObject("Cart",cart);
        return Ok();
    }
}