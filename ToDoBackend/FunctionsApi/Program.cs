using Infrastructure.Persistence.Context;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Mappings;
using ToDo.Application.Validation;
using FluentValidation;
using ToDo.Core.Interfaces;
using Infrastructure.Persistence.Repositories;
using ToDo.Application.Services;
using ToDo.Application.Services.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);
var ConnectionString = Environment.GetEnvironmentVariable("ToDoDBConnectionString");
builder.Services.AddDbContextFactory<ToDoDBContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddAutoMapper(config => { config.AddProfile(new MappingProfile()); });
builder.Services.AddValidatorsFromAssemblyContaining<CreateToDoItemValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateToDoItemValidator>();
builder.Services.AddTransient<IToDoRespository, ToDoRepository>();
builder.Services.AddTransient<IToDoService, ToDoService>();

builder.ConfigureFunctionsWebApplication();
// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
