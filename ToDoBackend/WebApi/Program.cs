using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Mappings;
using ToDo.Application.Services;
using ToDo.Application.Services.Interfaces;
using ToDo.Application.Validation;
using ToDo.Core.Interfaces;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ToDoDBConnectionString");
builder.Services.AddDbContextFactory<ToDoDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(config => { config.AddProfile(new MappingProfile()); });
builder.Services.AddValidatorsFromAssemblyContaining<CreateToDoItemValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateToDoItemValidator>();
builder.Services.AddTransient<IToDoRespository, ToDoRepository>();
builder.Services.AddTransient<IToDoService, ToDoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
