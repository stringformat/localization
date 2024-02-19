using Localization.Domain;
using Localization.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<LocalizationContext>(optionsBuilder => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Localization"));

var app = builder.Build();

app.MapGet("/question/create", async (IService service) => await service.CreateQuestion());

app.MapGet("/question/{id}", async (Guid id, IService service) => await service.GetQuestion(id));

app.Run();