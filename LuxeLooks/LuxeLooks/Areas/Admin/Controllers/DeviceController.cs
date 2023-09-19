using System.Net;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Response;
using LuxeLooks.Service;
using Microsoft.AspNetCore.Mvc;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace AppleStore.Areas.Admin.Controllers;

[Area("Admin")]
public class DeviceController : Controller
{
    private readonly ProductService _productService;
    private readonly ILogger<DeviceController> _logger;

    public DeviceController(ProductService productService, ILogger<DeviceController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<IActionResult> GetDevices()
    {
        bool useCache = false;
        BaseResponse<IEnumerable<Product>> response = await _productService.GetDevices(useCache);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            //return RedirectToAction("Error");
        }
        return View(response.Data);
    }

    public async Task<IActionResult> Edit(int id)
    {
        BaseResponse<Product> response = await _productService.GetById(id);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            //return RedirectToAction("Error");
        }

        return View(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product device)
    {
        BaseResponse<Product> response = await _productService.Edit(device);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
           // return View("Error",response.Description);
        }
        return RedirectToAction("GetDevices");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product device)
    {
        BaseResponse<bool> response = await _productService.CreateDevice(device);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
           // return View("Error",response.Description);
        }
        return RedirectToAction("GetDevices");
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        BaseResponse<bool> response = await _productService.DeleteDevice(id);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            _logger.LogError($"Error : {response.Description}");
            //return View("Error",response.Description);
        }
        return RedirectToAction("GetDevices");
    }
}