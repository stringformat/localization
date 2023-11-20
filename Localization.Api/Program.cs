using Localization.Domain;
using Localization.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<LocalizationContext>(optionsBuilder => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Localization"));

var app = builder.Build();

app.MapGet("/create", async (IService service) => await service.CreateQuestion());

app.MapGet("/get", async (IService service) => await service.GetQuestion());

app.Run();