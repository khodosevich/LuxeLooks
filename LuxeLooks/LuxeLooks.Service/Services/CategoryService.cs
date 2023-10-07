using System.Net;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Enum;
using LuxeLooks.Domain.Response;

namespace LuxeLooks.Service.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<BaseResponse<bool>> CreateCategory(Category category)
    {
        await _categoryRepository.Create(category);
        return new BaseResponse<bool>() { StatusCode = HttpStatusCode.OK };
    }

    public async Task<BaseResponse<List<Category>>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();
        if (categories.Count==0)
        {
            return new BaseResponse<List<Category>>() { StatusCode = HttpStatusCode.NoContent };
        }
        return new BaseResponse<List<Category>>() { Data = categories, StatusCode = HttpStatusCode.OK };
    }

    public async Task<BaseResponse<Category>> GetByType(ProductType type)
    {
        var category = (await _categoryRepository.GetAll()).FirstOrDefault(a => a.ProductType == type);
        if (category==null)
        {
            return new BaseResponse<Category>() { StatusCode = HttpStatusCode.NoContent };
        }

        return new BaseResponse<Category>() { Data = category, StatusCode = HttpStatusCode.OK };
    }
}