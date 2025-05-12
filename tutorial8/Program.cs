using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tutorial8.Middlewares;
using tutorial8.Services.Extensions;
using tutorial8.Infrastructure.Repositories.Extensions;
using tutorial8.Contracts.Requests;
using tutorial8.Contracts.Responses;
using tutorial8.Entities;
using tutorial8.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApplicationServices()   
    .AddInfrastructureServices()
    .AddProblemDetails(); 

builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); 

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map the API controllers
app.MapControllers();

app.Run();