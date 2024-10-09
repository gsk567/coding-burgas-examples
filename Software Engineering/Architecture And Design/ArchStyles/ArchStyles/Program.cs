using Clean.Application;
using Clean.Infrastructure;
using Clean.Infrastructure.Persistence;
using Layered.Data;
using Layered.Services;
using Layered.Services.Contracts;
using Layered.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLayeredData(builder.Configuration);
builder.Services.AddLayeredServices();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello Arch Styles");

if (app.Environment.IsDevelopment())
{
    app.MapGet("/--init-db", (
        LayeredEntityContext layeredContext,
        CleanEntityContext cleanContext) =>
    {
        cleanContext.Database.EnsureCreated();
        layeredContext.Database.EnsureCreated();
        return Results.Ok("Databases initalized");
    });
}

app.MapControllers();

app.Run();
