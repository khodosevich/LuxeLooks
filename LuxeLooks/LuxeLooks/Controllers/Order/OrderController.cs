using System.Net;
using LuxeLooks.Domain.Enum;
using LuxeLooks.Domain.Models;
using LuxeLooks.Domain.Response;
using LuxeLooks.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.Order;

[Route("Order")]
public class OrderController : Controller
{
    private readonly OrderService _orderService;
    private readonly ILogger<OrderController> _logger;
    private readonly UserService _userService;

    public OrderController(OrderService orderService, ILogger<OrderController> logger,  UserService userService)
    {
        _orderService = orderService;
        _logger = logger;
        _userService = userService;
    }
    private IActionResult HandleResponse<T>(BaseResponse<T> response)
    {
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Response from service status is not OK: {response.StatusCode}");
            return StatusCode((int)response.StatusCode, response.Description);
        }

        return Ok(response.Data);
    }
    
    [Authorize]
    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromBody]OrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid data");
        }
        if (!Guid.TryParse(request.UserId, out var userId))
        {
            return BadRequest("Invalid ID format");
        }

        foreach (var productId in request.ProductsIds)
        {
            if (!Guid.TryParse(productId, out var guidProductId))
            {
                return BadRequest("Invalid products ID format");
            }
        }
        List<Guid> productsIds = request.ProductsIds.Select(Guid.Parse).ToList();
        var userResponse = await _userService.GetByIdAsync(request.UserId);
        if (userResponse.StatusCode!=HttpStatusCode.OK)
        {
            return HandleResponse(userResponse);
        }

        var order = new Domain.Entity.Order()
        {
            Name = request.Name,
            Address = request.Address,
            Email = request.Email,
            Price = request.Price,
            ProductsIds = productsIds,
            Status = OrderStatus.Processing,
            UserId = userId,
            CreateTime = DateTime.Now
        };
        await _orderService.CreateOrder(order);
        return Ok();
    }

    [Authorize]
    [HttpGet("GetOrderByUserId/{id}")]
    public async Task<IActionResult> GetOrdersByUserId(string id)
    {
        bool useCache = false;
        if (!Guid.TryParse(id, out var guid))
        {
            return BadRequest("Invalid ID format");
        }
        var response=await _orderService.GetOrders(useCache);
        if (response.StatusCode!=HttpStatusCode.OK)
        {
            return HandleResponse(response);
        }
        var orders = response.Data.Where(order => order.UserId == guid).ToList();
        return Ok(orders);
    }
    
}