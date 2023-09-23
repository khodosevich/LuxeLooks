using System.Net;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Response;
using LuxeLooks.Domain.ViewModels;
using LuxeLooks.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LuxeLooks.Controllers.Order;

public class OrderController : Controller
{
    private readonly OrderService _orderService;
    private readonly ProductService _productService;
    private readonly ILogger<OrderController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderController(OrderService orderService, ProductService productService, ILogger<OrderController> logger,
        UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _orderService = orderService;
        _productService = productService;
        _logger = logger;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    [Authorize]
    [HttpGet("Place-Order")]
    public async Task<IActionResult> PlaceOrder(List<Guid> ids)
    {
        IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
        BaseResponse<IEnumerable<Product>> response = await _productService.GetDevices(true);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            return StatusCode((int)response.StatusCode, response.Description);
        }

        _logger.LogInformation("Успешное получение Девайса из базы данных");
        List<Product> products = response.Data
            .SelectMany(device =>
                ids.Contains(device.Id)
                    ? Enumerable.Repeat(device, ids.Count(id => id == device.Id))
                    : Enumerable.Empty<Product>())
            .ToList();

        ProductOrderViewModel model = new ProductOrderViewModel()
        {
            Products = products,
            Order = new Domain.Entity.Order()
                { ProductsIds = ids, UserId = new Guid(user.Id), Email = user.Email }
        };
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(ProductOrderViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            foreach (var key in ModelState.Keys)
            {
                var fieldState = ModelState[key];
                if (fieldState.ValidationState == ModelValidationState.Invalid)
                {
                    var errors = fieldState.Errors;
                    foreach (var error in errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        _logger.LogError(errorMessage);
                    }
                }
            }

            return BadRequest();
        }

        _httpContextAccessor.HttpContext.Session.Remove("Cart");
        await _orderService.CreateOrder(viewModel.Order);
        _logger.LogInformation("Успешное создание заказа");
        return Ok();
    }

    public async Task<IActionResult> GetOrdersHistory(Guid userId)
    {
        bool useCache = false;
        BaseResponse<IEnumerable<Domain.Entity.Order>> response = await _orderService.GetOrders(useCache);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            return StatusCode((int)response.StatusCode, response.Description);
        }

        List<ProductOrderViewModel> models = new List<ProductOrderViewModel>();
        foreach (var order in response.Data)
        {
            if (order.UserId == userId)
            {
                List<Product> products = new List<Product>();
                foreach (var id in order.ProductsIds)
                {
                        products.Add((await _productService.GetById(id)).Data!);
                }

                models.Add(new ProductOrderViewModel() { Products = products, Order = order });
            }
        }

        return Ok(models);
    }

    public async Task<IActionResult> Delete(Guid orderId)
    {
        BaseResponse<bool> response = await _orderService.DeleteOrder(orderId);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            return StatusCode((int)response.StatusCode, response.Description);
        }

        string userId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
        return RedirectToAction("GetOrdersHistory", new { userId = userId });
    }
}