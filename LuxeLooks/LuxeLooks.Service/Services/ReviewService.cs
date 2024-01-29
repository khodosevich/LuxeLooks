using System.Net;
using LuxeLooks.DataManagment.Repositories.Interfaces;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Models;
using LuxeLooks.SharedLibrary;
using LuxeLooks.SharedLibrary.Mappers;

namespace LuxeLooks.Service.Services;

public class ReviewService
{
    private readonly IBaseRepository<Review> _reviewRepository;
    private readonly StringToGuidMapper _guidMapper;
    private readonly UserService _userService;
    private readonly ProductService _productService;
    private readonly OrderService _orderService;

    public ReviewService(IBaseRepository<Review> reviewRepository, StringToGuidMapper guidMapper, UserService userService, ProductService productService, OrderService orderService)
    {
        _reviewRepository = reviewRepository;
        _guidMapper = guidMapper;
        _userService = userService;
        _productService = productService;
        _orderService = orderService;
    }

    private async Task<bool> HasUserOrderedProduct(string userId, string productId)
    {
        var guidProductId = _guidMapper.MapTo(productId);
        var orders = await _orderService.GetByUserId(userId);
        foreach (var order in orders)
        {
            if (order.ProductsIds.Contains(guidProductId))
            {
                return true;
            }
        }
        return false;
    }

    public async Task<List<Review>> GetByProductId(string id)
    {
        var productId = _guidMapper.MapTo(id);
        var response = await _productService.GetById(productId);
        if (response.StatusCode!=HttpStatusCode.OK)
        {
            throw new InvalidOperationException($"Product with id: {id} is not found");
        }
        var reviews = await _reviewRepository.GetAll();
        if (reviews.Count==0)
        {
            throw new InvalidOperationException("Reviews are not found");
        }

        return reviews.Where(a => a.ProductId == productId).ToList();
    }
    

    public async Task Create(ReviewRequest reviewRequest)
    {
        var productId = _guidMapper.MapTo(reviewRequest.ProductId);
        var userId = _guidMapper.MapTo(reviewRequest.UserId);
        var productResponse = await _productService.GetById(productId);
        var userResponse = await _userService.GetByIdAsync(userId);
        if (productResponse.StatusCode!=HttpStatusCode.OK)
        {
            throw new InvalidOperationException($"Product with id: {productId} is not found");
        }
        if (userResponse.StatusCode!=HttpStatusCode.OK)
        {
            throw new InvalidOperationException($"User with id: {userId} is not found");
        }

        bool isUserCanCreateReview = await HasUserOrderedProduct(reviewRequest.UserId, reviewRequest.ProductId);
        if (!isUserCanCreateReview)
        {
            throw new InvalidOperationException(
                $"User with id: {userId} cant create review on product with id: {productId}");
        }
        var review = new Review()
        {
            CreateDate = DateTime.Now.ToUniversalTime(),
            ProductId = productId,
            Title = reviewRequest.Title,
            UserId = userId
        };
        await _reviewRepository.Create(review);
    }

    public async Task<List<Review>> GetByUserId(string userId)
    {
        var guidUserId = _guidMapper.MapTo(userId);
        var response = await _userService.GetByIdAsync(guidUserId);
        if (response.StatusCode!=HttpStatusCode.OK)
        {
            throw new InvalidOperationException($"User with id: {userId} is not found");
        }
        var reviews = await _reviewRepository.GetAll();
        if (reviews.Count==0)
        {
            throw new InvalidOperationException("Reviews are not found");
        }

        return reviews.Where(a => a.UserId == guidUserId).ToList();
    }
}