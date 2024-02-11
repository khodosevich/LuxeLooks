using System.Net;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Enum;
using LuxeLooks.Domain.Extensions;
using LuxeLooks.Domain.Models;
using LuxeLooks.Domain.Models.Requests;
using LuxeLooks.Domain.Response;
using LuxeLooks.SharedLibrary.Mappers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace LuxeLooks.Service.Services;

public class ProductService 
{
    private readonly ProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;
    private readonly IMemoryCache _cache;
    private readonly StringToGuidMapper _guidMapper;

    public ProductService(ProductRepository productRepository, ILogger<ProductService> logger, IMemoryCache cache, StringToGuidMapper guidMapper)
    {
        _productRepository = productRepository;
        _logger = logger;
        _cache = cache;
        _guidMapper = guidMapper;
    }

    public List<ProductResponse> GetProductResponsesFromProducts(IEnumerable<Product> products)
    {
        var productResponses = new List<ProductResponse>();
        return products
            .Select(product => new ProductResponse(product)
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Type = product.Type.DisplayName()
            })
            .ToList();
    }
    public async Task<BaseResponse<ProductResponse>> GetById(Guid id)
    {
        var response = new BaseResponse<ProductResponse>();

        var product = (await _productRepository.GetAll()).FirstOrDefault(x=>x.Id==id);
        if (product == null)
        {
            response.Description = "Девайс не найден";
            response.StatusCode = HttpStatusCode.NoContent;
            _logger.LogError("Ошибка : девайсы не найдены");
            return response;
        }
        response.StatusCode = HttpStatusCode.OK;
        response.Data = new ProductResponse(product);
        return response;
    }

    public async Task<BaseResponse<ProductResponse>> GetByName(string name)
    {
        var response = new BaseResponse<ProductResponse>();

        var product = (await _productRepository.GetAll()).FirstOrDefault(x=>x.Name==name);
        if (product == null)
        {
            response.Description = "Девайс не найден";
            response.StatusCode = HttpStatusCode.NoContent;
            _logger.LogError("Ошибка : девайсы не найдены");
            return response;
        }

        response.StatusCode = HttpStatusCode.OK;
        response.Data = new ProductResponse(product);
        _logger.LogInformation("Успешное получение девайса");
        return response;
    }

    public async Task<BaseResponse<bool>> CreateProduct(Product model)
    {
        var response = new BaseResponse<bool>();
        var product = new Product()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Type = (ProductType)Convert.ToInt32(model.Type),
            ImageUrl = model.ImageUrl,
            IsForKids = model.IsForKids,
            IsForMen = model.IsForMen,
        };
        await _productRepository.Create(product);
        response.StatusCode = HttpStatusCode.OK;
        response.Data = true;
        _logger.LogInformation("Успешное создание девайса");
        return response;
    }

    public async Task<BaseResponse<List<ProductResponse>>> GetProducts(bool useCache)
    {
        var response = new BaseResponse<List<ProductResponse>>();
        
        if (useCache && _cache.TryGetValue("AllDevices", out IEnumerable<Product>? productsFromCache))
        {
            _logger.LogInformation("Получение всех девайсов из кэша");
            
            response.Data = GetProductResponsesFromProducts(productsFromCache);
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        try
        {
            var products = await _productRepository.GetAll();
            if (products.Count == 0)
            {
                response.Description = "Найдено 0 элементов";
                response.StatusCode = HttpStatusCode.NoContent;
                _logger.LogError("Ошибка : девайсы не найдены");
                return response;
            }
            response.Data = GetProductResponsesFromProducts(products);
            response.StatusCode = HttpStatusCode.OK;
            
            if (useCache)
            {
                _cache.Set("AllDevices", products,
                    new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
                _logger.LogInformation("Все девайсы добавлены в кэш");
            }
            return response;
        }
        catch (Exception exception)
        {
            _logger.LogCritical("Возникло исключение при получении всех девайсов");
            return new BaseResponse<List<ProductResponse>>()
            {
                Description = $"[GetDevices] : {exception.Message}",
                StatusCode = HttpStatusCode.NoContent
            };
        }
    }

    public async Task<BaseResponse<List<ProductResponse>>> GetManyProducts(List<Guid> ids)
    {
        var response = new BaseResponse<List<ProductResponse>>();
        var products=(await _productRepository.GetAll()) .Where(product => ids.Contains(product.Id))
            .ToList();
        if (products.Count==0)
        {
            response.Description = "No products with ids";
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }

        response.Data = GetProductResponsesFromProducts(products);
        response.StatusCode = HttpStatusCode.OK;
        return response;
    }

    public async Task UpdateProduct(Product product)
    {
        var productFromRepository = (await _productRepository.GetAll()).FirstOrDefault(a => a.Id == product.Id);
        if (productFromRepository==null)
        {
            throw new InvalidOperationException("Product not found");
        }

        productFromRepository.Description = product.Description;
        productFromRepository.IsForKids = product.IsForKids;
        productFromRepository.IsForMen = product.IsForMen;
        productFromRepository.ImageUrl = product.ImageUrl;
        productFromRepository.Name = product.Name;
        productFromRepository.Price = product.Price;
        productFromRepository.Type = product.Type;
        await _productRepository.Update(productFromRepository);
    }

    public async Task DeleteProduct(string id)
    {
        var guidId = _guidMapper.MapTo(id);
        var productFromRepository = (await _productRepository.GetAll()).FirstOrDefault(a => a.Id == guidId);
        if (productFromRepository==null)
        {
            throw new InvalidOperationException("Product not found");
        }
        await _productRepository.Delete(productFromRepository);
    }
}