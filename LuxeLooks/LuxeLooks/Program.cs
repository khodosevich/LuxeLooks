using LuxeLooks.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.AddIdentity();
builder.AddDataBase();

var app = builder.Build();
app.UseAuthorization();

app.MapControllers();
app.Run();