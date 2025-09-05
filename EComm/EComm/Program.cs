using EComm.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<Repository>(_ => 
    new Repository());

var app = builder.Build();

app.MapOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
