using LuxeLooks.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LuxeLooks.Controllers;

[Route("Account")]
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [AllowAnonymous]
    [HttpGet("IsUserAutorized")]
    public IActionResult IsUserAutorized()
    {
        if (User.Identity.IsAuthenticated)
            return Ok();
        return Unauthorized();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            IdentityUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var roles=await _userManager.GetRolesAsync(user);
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Пользователь {model.UserName} Авторизовался успешно");
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToRoute("Admin",new{area="Admin", controller="Home",action="Index"});
                    }
                    return RedirectToAction("GetAccountPage");
                }
                else if (!result.IsLockedOut && !result.IsNotAllowed && !result.RequiresTwoFactor)
                {
                    _logger.LogInformation("Авторизация прошла неуспешно : неверный пароль");
                    return View("Error", "Неверный пароль");
                }
                
            }
            _logger.LogError("Авторизация прошла неуспешно : пользователь не найден");
            return View("Error", "Пользователь не найден");
        }
            
        return View("Error","Некорректный логин или пароль");
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            IdentityUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user!=null)
            {
                //return View("Error", "Пользователь уже существует");
            }
            var newUser = new IdentityUser { UserName = model.UserName,Email = model.Email};
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("Зареган");
                await _signInManager.SignInAsync(newUser, isPersistent: false); // Log in the user
                return RedirectToAction("GetAccountPage");
            }
        }
        foreach (var key in ModelState.Keys)
        {
            var fieldState = ModelState[key];
            if (fieldState.ValidationState == ModelValidationState.Invalid)
            {
                var errors = fieldState.Errors;
                foreach (var error in errors)
                {
                    var errorMessage = error.ErrorMessage;
                    _logger.LogError(errorMessage);
                }
            }
        }
        return View("Error", "Некорректный логин или пароль");
    }
    
    public async Task<IActionResult> Logout()
    {
        if (!User.Identity.IsAuthenticated)
            return View("Error", "Вы не вошли в аккаунт");
        await _signInManager.SignOutAsync(); 
        return View("Successful","Вы вышли из аккаунта");
    }

    [Authorize]
    public async Task<IActionResult> GetAccountPage()
    {
        string userId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
        return View("GetAccountPage",userId);
    }
}