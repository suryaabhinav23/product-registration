using BusinessLayer;
using DataLayer;
using DataLayer.IData;
using Entities;
using Microsoft.AspNetCore.Mvc;
using ProductRegistration.Controllers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Connections>(builder.Configuration.GetSection("Connections"));

builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddTransient<IUserData, UserData>();


builder.Services.AddTransient<IEquipmentsBusiness, EquipmentsBusiness>();
builder.Services.AddTransient<IEquipmentsData, EquipmentsData>();

builder.Services.AddTransient<IStatusBusiness, StatusBusiness>();
builder.Services.AddTransient<IStatusData, StatusData>();



WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
