using System.Net;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Response;

namespace LuxeLooks.Service.Services;

public class SubcsribeService
{
    private readonly SubcribeRepository _subcribeRepository;

    public SubcsribeService(SubcribeRepository subcribeRepository)
    {
        _subcribeRepository = subcribeRepository;
    }

    public async Task<BaseResponse<bool>> CreateSubscribe(Subscribe subscribe)
    {
        await _subcribeRepository.Create(subscribe);
        return new BaseResponse<bool>()
        {
            Data = true,
            StatusCode = HttpStatusCode.OK
        };
    }
}