using EComm.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EFRepository>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")!));

//builder.Services.AddScoped<Repository>(_ => 
//    new Repository(builder.Configuration.GetConnectionString("ConnStr")!));

var app = builder.Build();

app.MapOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
