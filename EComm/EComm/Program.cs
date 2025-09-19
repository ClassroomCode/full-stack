using EComm;
using EComm.DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EFRepository>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")!));

//builder.Services.AddScoped<Repository>(_ => 
//    new Repository(builder.Configuration.GetConnectionString("ConnStr")!));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostAnyPort", builder =>
    {
        builder.SetIsOriginAllowed(origin =>
        {
            Uri uri = new Uri(origin);
            return uri.Host == "localhost" || uri.Host == "127.0.0.1";
        })
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, MyCustomAuthHandler>
        ("MyCustomAuth", options => { });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminsOnly", policy =>
        policy.RequireClaim("ClaimTypes.Role", "Admin"));
});

var app = builder.Build();

app.UseExceptionHandler("/error");

app.MapOpenApi();

app.UseCors("AllowLocalhostAnyPort");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
