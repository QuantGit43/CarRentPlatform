using CarRentPlatform.Configurations;
using CarRentPlatform;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;
builder.Services.AddDbContext<CarRentDBContext>
    (options =>
        options.UseNpgsql(config.GetConnectionString(nameof(CarRentDBContext))));    

var app = builder.Build();

app.UseSwagger();     
app.UseSwaggerUI();
