using LuxeLooks.Extensions;
using LuxeLooks.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LuxeLooks.Domain.Models;

namespace LuxeLooks.Controllers.Cart;

[Route("Cart")]
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
    
    [Authorize]
    [HttpGet("GetCart")]
    public async Task<IActionResult> GetCart()
    {
        List<Guid>? cart = _httpContextAccessor.HttpContext.Session.GetObject<List<Guid>>("Cart");
        if (cart != null)
        {
            var response = await _productService.GetProducts(false);
            var products = response.Data.SelectMany((ProductResponse product) =>
                    cart.Contains(product.Id)
                        ? Enumerable.Repeat(product, cart.Count(id => id == product.Id))
                        : Enumerable.Empty<ProductResponse>())
                .ToList();
            _logger.LogInformation("Successfully get cart");
            return Ok(products);
        }
        _logger.LogError("Cart data is failed");
        return NoContent();
    } 
    
    [Authorize]
    [HttpPut("AddToCart")]
    public IActionResult AddToCart([FromBody]CartRequest request)
    {
        if (!Guid.TryParse(request.Id, out var productId))
        {
            _logger.LogError("Invalid ID format");
            return BadRequest("Invalid ID format");
        }
        List<Guid> cart = _httpContextAccessor.HttpContext.Session.GetObject<List<Guid>>("Cart") ?? new List<Guid>();
        cart.Add(productId);
        _httpContextAccessor.HttpContext.Session.SetObject("Cart",cart);
        _logger.LogInformation($"Successfully added product with id: {request.Id}");
        return Ok();
    }
    [Authorize]
    [HttpDelete("RemoveFromCart")]
    public IActionResult RemoveFromCart([FromBody]CartRequest request)
    {
        if (!Guid.TryParse(request.Id, out var productId))
        {
            _logger.LogError("Invalid ID format");
            return BadRequest("Invalid ID format");
        }
        
        List<Guid> cart = _httpContextAccessor.HttpContext.Session.GetObject<List<Guid>>("Cart") ?? new List<Guid>();
        cart.Remove(productId);
        _httpContextAccessor.HttpContext.Session.SetObject("Cart",cart);
        _logger.LogInformation($"Successfully deleted product with id: {request.Id}");
        return Ok();
    }
}