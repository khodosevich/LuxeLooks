using System.Net;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Response;
using Microsoft.Extensions.Logging;

namespace LuxeLooks.Service.Services;

public class RoleService
{
    private readonly RoleRepository _roleRepository;
    private readonly ILogger<RoleService> _logger;

    public RoleService(RoleRepository roleRepository, ILogger<RoleService> logger)
    {
        _roleRepository = roleRepository;
        _logger = logger;
    }
    private BaseResponse<T> HandleError<T>(string description,HttpStatusCode error)
    {
        var response = new BaseResponse<T>
        {
            StatusCode = error,
            Description = description
        };
        _logger.LogError(description);
        return response;
    }

    public async Task<BaseResponse<List<Role>>> GetAllAsync()
    {
        var roles = await _roleRepository.GetAll();
        if (roles.Count==0)
        {
           return HandleError<List<Role>>("Roles are not found", HttpStatusCode.NoContent);
        }
        return new BaseResponse<List<Role>> { Data = roles, StatusCode = HttpStatusCode.OK };
    }

    public async Task<BaseResponse<Role>> GetByIdAsync(Guid id)
    {
        var role =(await _roleRepository.GetAll()).FirstOrDefault(a=>a.Id==id);
        if (role==null)
        {
           return HandleError<Role>($"Role with id: {id} not found", HttpStatusCode.NoContent);
        }
        _logger.LogInformation($"Successfully get role with id: {id}");
        return new BaseResponse<Role>() { Data = role, StatusCode = HttpStatusCode.OK };
    }
}