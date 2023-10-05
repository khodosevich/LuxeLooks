using System.Net;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Response;
using Microsoft.Extensions.Logging;

namespace LuxeLooks.Service.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(UserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    private BaseResponse<T> HandleError<T>(string description, HttpStatusCode error)
    {
        var response = new BaseResponse<T>
        {
            StatusCode = error,
            Description = description
        };
        _logger.LogError(description);
        return response;
    }

    private Task<List<User>> CorrectUsersRefreshTokenExpiryTime(List<User> users)
    {
        return Task.FromResult(users.Select(user =>
        {
            user.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            return user;
        }).ToList());
    }

    public async Task<BaseResponse<bool>> CreateAsync(User user, string password)
    {
        var workFactor = 12;
        var salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        user.PasswordSalt = salt;
        user.PasswordHash = hashedPassword;
        user.NormalizedUserName = user.UserName.ToUpper();
        await _userRepository.Create(user);
        return new BaseResponse<bool>() { StatusCode = HttpStatusCode.OK };
    }


    public async Task<BaseResponse<User>> GetByIdAsync(Guid id)
    {
        var user = (await _userRepository.GetAll()).FirstOrDefault(a=>a.Id==id);
        if (user == null)
        {
            return HandleError<User>($"User with id: {id} not found", HttpStatusCode.NoContent);
        }

        user=(await CorrectUsersRefreshTokenExpiryTime(new List<User>() { user }))[0];
        _logger.LogInformation($"Successfully get user with id: {id}");
        return new BaseResponse<User>() { Data = user, StatusCode = HttpStatusCode.OK };
    }

    public async Task<BaseResponse<User>> FindByNameAsync(string userName)
    {
        var user = (await _userRepository.GetAll()).FirstOrDefault(a => a.UserName == userName);
        if (user == null)
        {
            return HandleError<User>($"User with username: {userName} not found", HttpStatusCode.NoContent);
        }
        user=(await CorrectUsersRefreshTokenExpiryTime(new List<User>() { user }))[0];
        return new BaseResponse<User>() { Data = user, StatusCode = HttpStatusCode.OK };
    }

    public async Task<BaseResponse<bool>> UpdateAsync(User user)
    {
        var findUser = (await _userRepository.GetAll()).FirstOrDefault(a=>a.Id==user.Id);
        if (findUser == null)
        {
            return HandleError<bool>($"User with id: {findUser.Id} not found", HttpStatusCode.NoContent);
        }

        findUser.RefreshTokenExpiryTime=findUser.RefreshTokenExpiryTime.ToUniversalTime();
        await _userRepository.Update(findUser);
        return new BaseResponse<bool>() { StatusCode = HttpStatusCode.OK };
    }

    public async Task<BaseResponse<bool>> CheckPasswordAsync(User user, string password)
    {
        var findUser = (await _userRepository.GetAll()).FirstOrDefault(a=>a.Id==user.Id);
        if (findUser == null)
        {
            return HandleError<bool>($"User with id: {user.Id} not found", HttpStatusCode.NoContent);
        }
        
        var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, findUser.PasswordHash);

        return new BaseResponse<bool>()
        {
            Data = isPasswordValid,
            StatusCode = HttpStatusCode.OK
        };
    }
    
    public async Task<BaseResponse<List<User>>> GetAllAsync()
    {
        var users =  await _userRepository.GetAll();
        if (users.Count == 0)
        {
            return HandleError<List<User>>("Users are not found", HttpStatusCode.NoContent);
        }
        users=await CorrectUsersRefreshTokenExpiryTime(users);
        return new BaseResponse<List<User>>() { Data = users, StatusCode = HttpStatusCode.OK };
    }
}