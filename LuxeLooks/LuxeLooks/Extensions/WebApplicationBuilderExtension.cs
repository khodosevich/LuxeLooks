using System.Text;
using LuxeLooks.DataManagment;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.DataManagment.Repositories.Implementations;
using LuxeLooks.DataManagment.Repositories.Interfaces;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Service.Services;
using LuxeLooks.SharedLibrary.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;

namespace LuxeLooks.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void AddDataBase(this WebApplicationBuilder builder)
    {
        string? deviceConnection = builder.Configuration.GetConnectionString("ConnectionString");
        builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(deviceConnection); });
    }

    public static void AddSession(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
        });
    }

    public static void AddAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
                    ValidAudience = builder.Configuration["Jwt:Audience"]!,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
                };
            });
        builder.Services.AddAuthorization(options => options.DefaultPolicy =
            new AuthorizationPolicyBuilder
                    (JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminArea", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Admin");
            });
        });
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<TokenService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<OrderRepository>();
        builder.Services.AddScoped<ProductRepository>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<RoleService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<RoleRepository>();
        builder.Services.AddScoped<SubcribeRepository>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<SubcsribeService>();
        builder.Services.AddScoped<CategoryRepository>();
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<IBaseRepository<Review>, ReviewRepository>();
        builder.Services.AddScoped<StringToGuidMapper>();
        builder.Services.AddScoped<ReviewService>();
    }

    public static void AddLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
    }

    public static void AddCache(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
    }
}