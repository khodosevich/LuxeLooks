using LuxeLooks.Extensions;
using NLog;
using NLog.Web;
using LogLevel = NLog.LogLevel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.AddDataBase();
builder.AddAuthentication();
builder.AddSession();
builder.AddServices();
builder.AddLogging();
builder.AddCache();
builder.AddSwaggerDocumentation();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
}); 
app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers(); 
app.UseSwagger();
app.UseSwaggerUI();
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Log(LogLevel.Info,"Program initial");
app.Run();