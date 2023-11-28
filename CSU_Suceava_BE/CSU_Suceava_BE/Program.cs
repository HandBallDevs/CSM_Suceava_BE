using Azure.Identity;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Mapper;
using CSU_Suceava_BE.Application.Services;
using CSU_Suceava_BE.Infrastructure.Contexts;
using CSU_Suceava_BE.Infrastructure.Interfaces;
using CSU_Suceava_BE.Infrastructure.Repositories;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(
        new Uri($"https://{Environment.GetEnvironmentVariable("KEY_VAULT_NAME")}.vault.azure.net/"));

    clientBuilder.AddBlobServiceClient(
        new Uri($"https://{Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME")}.blob.core.windows.net/csusvbs"));

    clientBuilder.UseCredential(new DefaultAzureCredential());
});

builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddScoped<IIstoricPremiiRepository, IstoricPremiiRepository>();
builder.Services.AddScoped<IIstoricPremiiService, IstoricPremiiService>();

builder.Services.AddScoped<BlobStorageService>();

builder.Services.AddAutoMapper(typeof(StaffProfile));
builder.Services.AddAutoMapper(typeof(IstoricPremiiProfile));

builder.Services.AddDbContext<EFContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
