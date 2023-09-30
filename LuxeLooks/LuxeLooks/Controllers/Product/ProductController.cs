using System.Net;
using LuxeLooks.Domain.Enum;
using LuxeLooks.Domain.Models;
using LuxeLooks.Domain.Response;
using LuxeLooks.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace LuxeLooks.Controllers.Product;

[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductService _productService;
    private readonly NotificationService _notificationService;

    public ProductController(ILogger<ProductController> logger, ProductService productService,
        NotificationService notificationService)
    {
        _logger = logger;
        _productService = productService;
        _notificationService = notificationService;
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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllProducts()
    {
        bool useCache = false;
        var response = await _productService.GetProducts(useCache);
        return HandleResponse(response);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
        {
            return BadRequest("Invalid ID format");
        }

        var response = await _productService.GetById(guid);
        return HandleResponse(response);
    }

    [HttpGet("GetByName/{username}")]
    public async Task<IActionResult> GetProductByName(string userName)
    {
        var response = await _productService.GetByName(userName);
        return HandleResponse(response);
    }

    [HttpGet("GetMany/{productsIds}")]
    public async Task<IActionResult> GetManyProductsByIds(List<string> productsIds)
    {
        foreach (var productId in productsIds)
        {
            if (!Guid.TryParse(productId, out var guidProductId))
            {
                return BadRequest("Invalid products ID format");
            }
        }

        List<Guid> guidProductsIds = productsIds.Select(Guid.Parse).ToList();
        var response = await _productService.GetManyProducts(guidProductsIds);
        return HandleResponse(response);
    }

    [HttpPut("CreateProduct")]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
    {
        if (!Enum.IsDefined(typeof(ProductType), request.Type))
        {
            return BadRequest("Invalid type of product");
        }

        var product = new Domain.Entity.Product()
        {
            Description = request.Description,
            Type = (ProductType)Enum.Parse(typeof(ProductType), request.Type),
            ImageUrl = request.ImageUrl,
            IsForKids = request.IsForKids,
            IsForMen = request.IsForMen,
            Name = request.Name,
            Price = request.Price
        };
        var response = await _productService.CreateProduct(product);
        if (response.StatusCode!=HttpStatusCode.OK)
        {
            return HandleResponse(response);
        }

        //await _notificationService.SendNotificationsForNewProductAsync(product);
        return Ok();
    }
}