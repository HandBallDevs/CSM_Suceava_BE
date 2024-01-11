using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.JwtUtils;
using CSU_Suceava_BE.Application.Mapper;
using CSU_Suceava_BE.Application.Services;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using CSU_Suceava_BE.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

// Secrets
var keyVaultUri = new Uri($"https://{Environment.GetEnvironmentVariable("KEY_VAULT_NAME")}.vault.azure.net/");
var secretClient = new SecretClient(keyVaultUri, new DefaultAzureCredential());
var token = secretClient.GetSecret(Environment.GetEnvironmentVariable("TOKEN_SECRET")).Value.Value;

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(token)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.Administrator, policy =>
    policy.RequireAssertion(context => context.User.Claims.First(x => x.Type == "Role").Value == Policies.Administrator));

    options.AddPolicy(Policies.CreatorDeContinut, policy =>
    policy.RequireAssertion(context => context.User.Claims.First(x => x.Type == "Role").Value == Policies.CreatorDeContinut));
});

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(new Uri($"https://{Environment.GetEnvironmentVariable("KEY_VAULT_NAME")}.vault.azure.net/"));
    clientBuilder.AddBlobServiceClient(new Uri($"https://{Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME")}.blob.core.windows.net/csusvbs"));
    clientBuilder.UseCredential(new DefaultAzureCredential());
});


builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddScoped<IMeciRepository, MeciRepository>();
builder.Services.AddScoped<IMeciService, MeciService>();

builder.Services.AddScoped<IIstoricPremiiRepository, IstoricPremiiRepository>();
builder.Services.AddScoped<IIstoricPremiiService, IstoricPremiiService>();

builder.Services.AddScoped<IIstoricRoluriRepository, IstoricRoluriRepository>();
builder.Services.AddScoped<IIstoricRoluriService, IstoricRoluriService>();

builder.Services.AddScoped<IUtilizatorRepository, UtilizatorRepository>();
builder.Services.AddScoped<IUtilizatorService, UtilizatorService>();

builder.Services.AddScoped<IJwtUtils, JwtUtils>();

builder.Services.AddScoped<BlobStorageService>();


builder.Services.AddAutoMapper(typeof(StaffProfile));
builder.Services.AddAutoMapper(typeof(IstoricPremiiProfile));
builder.Services.AddAutoMapper(typeof(IstoricRoluriProfile));
builder.Services.AddAutoMapper(typeof(MeciProfile));

builder.Services.AddDbContext<EFContext>();

// Application
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseCors("default");
// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS Redirection
app.UseHttpsRedirection();

// Routing
app.UseRouting();

// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers();

// JWT Middleware
app.UseMiddleware<JwtMiddleware>();

// Run the application


app.Run();
