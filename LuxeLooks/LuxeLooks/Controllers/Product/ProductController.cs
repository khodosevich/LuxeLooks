using System.Net;
using LuxeLooks.Domain.Entity;
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
    private readonly OrderService _orderService;
    private readonly CategoryService _categoryService;

    public ProductController(ILogger<ProductController> logger, ProductService productService,
        NotificationService notificationService, OrderService orderService, CategoryService categoryService)
    {
        _logger = logger;
        _productService = productService;
        _notificationService = notificationService;
        _orderService = orderService;
        _categoryService = categoryService;
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

    [HttpGet("GetByName/{name}")]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var response = await _productService.GetByName(name);
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

    [HttpGet("GetPopularProducts")]
    public async Task<IActionResult> GetPopularProducts()
    {
        var orderResponse = await _orderService.GetOrders(true);
        var productsResponse = await _productService.GetProducts(true);
        if (orderResponse.StatusCode!=HttpStatusCode.OK)
        {
            return Ok(productsResponse.Data.Take(12));
        }

        var orders = orderResponse.Data;
        var products = productsResponse.Data;
        var recentOrders = orders.Where(order => order.CreateTime >= DateTime.Now.AddDays(-30)).ToList();

        // Создаем словарь для подсчета количества продаж каждого товара
        var productSalesCount = new Dictionary<Guid, int>();

        foreach (var order in recentOrders)
        {
            foreach (var productId in order.ProductsIds)
            {
                if (productSalesCount.ContainsKey(productId))
                {
                    productSalesCount[productId]++;
                }
                else
                {
                    productSalesCount[productId] = 1;
                }
            }
        }
        
        var sortedProducts = products.OrderByDescending(product => productSalesCount.ContainsKey(product.Id) ? productSalesCount[product.Id] : 0).ToList();
        var top12Products = sortedProducts.Take(12).ToList();
        return Ok(top12Products);
    }

    [HttpGet("GetPopularTypes")]
    public async Task<IActionResult> GetPopularTypes()
    { 
        var orderResponse = await _orderService.GetOrders(true);
        var productsResponse = await _productService.GetProducts(true);
        if (orderResponse.StatusCode!=HttpStatusCode.OK||productsResponse.StatusCode!=HttpStatusCode.OK)
        {
           return Ok((await _categoryService.GetAll()).Data.Take(6).ToList());
        }

        var orders = orderResponse.Data;
        var products = productsResponse.Data;
        var recentOrders = orders.Where(order => order.CreateTime >= DateTime.Now.AddDays(-30)).ToList();
        var productTypeSalesCount = new Dictionary<string, int>();
        
        foreach (var order in recentOrders)
        {
            foreach (var productId in order.ProductsIds)
            {
                var product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    if (productTypeSalesCount.ContainsKey(product.Type))
                    {
                        productTypeSalesCount[product.Type]++;
                    }
                    else
                    {
                        productTypeSalesCount[product.Type] = 1;
                    }
                }
            }
        }
        var top6ProductTypes = productTypeSalesCount.OrderByDescending(kv => kv.Value).Take(6).Select(kv => kv.Key).ToList();
        var enumValues = top6ProductTypes
            .Select(enumString => Enum.Parse(typeof(ProductType), enumString))
            .Cast<ProductType>()
            .ToList();
                
        var categories=(await _categoryService.GetAll()).Data.Where(category => enumValues.Contains(category.ProductType))
            .ToList();
        return Ok(categories);
    }
}