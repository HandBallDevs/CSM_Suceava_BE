<<<<<<< Updated upstream
using Microsoft.AspNetCore.Authentication.Cookies;
=======
using Azure.Identity;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Mapper;
using CSU_Suceava_BE.Application.Services;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using CSU_Suceava_BE.Infrastructure.Repositories;
using CSU_Suceava_BE.Helpers;
using CSU_Suceava_BE.Services;

using Microsoft.Extensions.Azure;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


///////////////////////////////////Login Feature////////////////////////////////////
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Account/Login"; //Pagina de Login (de completat) Completat Curent cu Views/TestLogin.html
});
<<<<<<< Updated upstream
/////////////////////////////////////////////////////////////////////////////////////
=======
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IUserService,UserService>();
>>>>>>> Stashed changes

builder.Services.AddAuthorization();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
