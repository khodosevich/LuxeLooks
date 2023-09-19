using LuxeLooks.DataManagment;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.Extensions;

public static class WebApplicationBuilderExtension
{
    
    public static void AddIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie( options=>
            {
                options.Cookie.Name = "LuxeLooksAuthentication";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Error";
                options.SlidingExpiration = true;
            });

    }

    public static void AddDataBase(this WebApplicationBuilder builder)
    {
        string? deviceConnection = builder.Configuration.GetConnectionString("ConnectionString");
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(deviceConnection));
    }
}