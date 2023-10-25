using LuxeLooks.DataManagment.Repositories.Interfaces;
using LuxeLooks.Domain.Response;

namespace LuxeLooks.Service.Services.Interfaces;

public interface IService<T>
{
    Task<BaseResponse<List<T>>> GetAll();
    Task<BaseResponse<T>> GetById(Guid id);
}