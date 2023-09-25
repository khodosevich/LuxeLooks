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

var app = builder.Build();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Log(LogLevel.Info,"Program initial");
app.Run();