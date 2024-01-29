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

    public ReviewService(IBaseRepository<Review> reviewRepository, StringToGuidMapper guidMapper)
    {
        _reviewRepository = reviewRepository;
        _guidMapper = guidMapper;
    }

    public async Task<List<Review>> GetByProductId(string id)
    {
        var productId = _guidMapper.MapTo(id);
        var reviews = await _reviewRepository.GetAll();
        if (reviews.Count==0)
        {
            throw new InvalidOperationException("Reviews are not found");
        }

        return reviews.Where(a => a.ProductId == productId).ToList();
    }

    public async Task Create(ReviewRequest reviewRequest)
    {
        var review = new Review()
        {
            CreateDate = DateTime.Now,
            ProductId = _guidMapper.MapTo(reviewRequest.ProductId),
            Title = reviewRequest.Title,
            UserId = _guidMapper.MapTo(reviewRequest.UserId)
        };
        await _reviewRepository.Create(review);
    }

    public async Task<List<Review>> GetByUserId(string userId)
    {
        var guidUserId = _guidMapper.MapTo(userId);
        var reviews = await _reviewRepository.GetAll();
        if (reviews.Count==0)
        {
            throw new InvalidOperationException("Reviews are not found");
        }

        return reviews.Where(a => a.UserId == guidUserId).ToList();
    }
}