using System.Net;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Response;
using LuxeLooks.Domain.ViewModels;
using LuxeLooks.Service;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly OrderService _orderService;
    private readonly ProductService _productService;

    public OrderController(ILogger<OrderController> logger,OrderService orderService, ProductService productService)
    {
        _logger = logger;
        _orderService = orderService;
        _productService = productService;
    }

    public async Task<IActionResult> GetOrders()
    {
        bool useCache = false;
        BaseResponse<IEnumerable<Order>> response = await _orderService.GetOrders(useCache);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
           // return View("Error",$"{response.Description}");
        }

        List<ProductOrderViewModel> models = new List<ProductOrderViewModel>();
        foreach (var order in response.Data)
        {
            List<Product> products = new List<Product>();
            foreach (var id in order.ProductsIds)
            {
                    var device = ((await _productService.GetById(id)).Data);
                    if (device != null)
                    {
                        products.Add(device);
                    }
            }
            models.Add(new ProductOrderViewModel(){Products = products,Order = order});
        }
        return View(models);
    }

    public async Task<IActionResult> Delete(Guid orderId)
    {
        BaseResponse < bool > response= await _orderService.DeleteOrder(orderId);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            //return View("Error",$"{response.Description}");
        }
        return RedirectToAction("GetOrders");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        BaseResponse<Order> response = await _orderService.GetById(id);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            //return View("Error",$"{response.Description}");
        }

        return View(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Order order)
    {
        BaseResponse<Order> response = await _orderService.Edit(order);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            //return View("Error",response.Description);
        }
        return RedirectToAction("GetOrders");
    }
}