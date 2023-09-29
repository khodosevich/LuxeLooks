using System.Net;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Enum;
using LuxeLooks.Domain.Response;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace LuxeLooks.Service.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly ILogger<OrderService> _logger;
    private readonly IMemoryCache _cache;

    public OrderService(OrderRepository orderRepository, ILogger<OrderService> logger, IMemoryCache cache)
    {
        _orderRepository = orderRepository;
        _logger = logger;
        _cache = cache;
    }

    public async Task<BaseResponse<Order>> GetById(Guid id)
    {
        var baseResponse = new BaseResponse<Order>();

        var order = (await _orderRepository.GetAll()).FirstOrDefault(x => x.Id == id);
        if (order == null)
        {
            baseResponse.Description = "Заказ не найден";
            baseResponse.StatusCode = HttpStatusCode.NoContent;
            _logger.LogError("Ошибка получения заказа");
            return baseResponse;
        }

        baseResponse.StatusCode = HttpStatusCode.OK;
        baseResponse.Data = order;
        _logger.LogInformation("Успешное получение заказа");
        return baseResponse;
    }

    public async Task<BaseResponse<Order>> GetByName(string name)
    {
        var baseResponse = new BaseResponse<Order>();

        var order = (await _orderRepository.GetAll()).FirstOrDefault(x => x.Name == name);
        if (order == null)
        {
            baseResponse.Description = "Заказ не найден";
            baseResponse.StatusCode = HttpStatusCode.NoContent;
            _logger.LogError("Ошибка получения заказа");
            return baseResponse;
        }

        baseResponse.StatusCode = HttpStatusCode.OK;
        baseResponse.Data = order;
        _logger.LogInformation("Успешное получение заказа");
        return baseResponse;
    }

    public async Task<BaseResponse<bool>> CreateOrder(Order orderModel)
    {
        var baseResponse = new BaseResponse<bool>();
        var order = new Order()
        {
            Name = orderModel.Name,
            ProductsIds = orderModel.ProductsIds,
            Email = orderModel.Email,
            Address = orderModel.Address,
            Price = orderModel.Price,
            Status = orderModel.Status,
            UserId = orderModel.UserId,
            CreateTime = DateTime.UtcNow
        };
        await _orderRepository.Create(order);
        baseResponse.StatusCode = HttpStatusCode.OK;
        baseResponse.Data = true;
        _logger.LogInformation("Успешное создание заказа");
        return baseResponse;
    }

    public async Task<BaseResponse<bool>> DeleteOrder(Guid id)
    {
        var baseResponse = new BaseResponse<bool>();

        var order = (await _orderRepository.GetAll()).FirstOrDefault(x => x.Id == id);
        if (order == null)
        {
            baseResponse.Description = "Заказ не найден";
            baseResponse.StatusCode = HttpStatusCode.NoContent;
            _logger.LogError("Ошибка получения заказа при попытке удаления заказа");
            return baseResponse;
        }

        await _orderRepository.Delete(order);
        baseResponse.StatusCode = HttpStatusCode.OK;
        baseResponse.Data = true;
        _logger.LogInformation("Успешное удаление заказа");
        return baseResponse;
    }

    public async Task<BaseResponse<IEnumerable<Order>>> GetOrders(bool useCache)
    {
        var baseResponse = new BaseResponse<IEnumerable<Order>>();

        if (useCache && _cache.TryGetValue("AllOrders", out IEnumerable<Order>? ordersFromCache))
        {
            _logger.LogInformation("Получение всех девайсов из кэша");
            baseResponse.Data = ordersFromCache;
            baseResponse.StatusCode = HttpStatusCode.OK;
            return baseResponse;
        }

        try
        {
            var orders = await _orderRepository.GetAll();
            if (orders.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = HttpStatusCode.NoContent;
                _logger.LogError("Ошибка : заказы не найдены");
                return baseResponse;
            }

            baseResponse.Data = orders;
            baseResponse.StatusCode = HttpStatusCode.OK;

            if (useCache)
            {
                _cache.Set("AllOrders", orders,
                    new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
                _logger.LogInformation("Все заказы добавлены в кэш");
            }

            return baseResponse;
        }
        catch (Exception exception)
        {
            _logger.LogCritical("Возникло исключение при получении всех заказов");
            return new BaseResponse<IEnumerable<Order>>()
            {
                Description = $"[GetDevices] : {exception.Message}"
            };
        }
    }

    public async Task<BaseResponse<Order>> Edit(Order model)
    {
        var baseResponse = new BaseResponse<Order>();
        try
        {
            var order = (await _orderRepository.GetAll()).FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                baseResponse.Description = "Заказ не найден";
                baseResponse.StatusCode = HttpStatusCode.NoContent;
                _logger.LogError("Ошибка получения заказа");
                return baseResponse;
            }

            order.Name = model.Name;
            order.ProductsIds = model.ProductsIds;
            order.Email = model.Email;
            order.Address = model.Address;
            order.Price = model.Price;
            order.Status = model.Status;
            order.UserId = model.UserId;

            await _orderRepository.Update(order);
            baseResponse.StatusCode = HttpStatusCode.OK;
            _logger.LogInformation("Успешное редактирование заказа");
            return baseResponse;
        }
        catch (Exception e)
        {
            var response = new BaseResponse<Order>();
            response.StatusCode = HttpStatusCode.NotFound;
            response.Description = e.Message;
            _logger.LogCritical("Возникло исключение при попытке редактирования заказа");
            return response;
        }
    }
}