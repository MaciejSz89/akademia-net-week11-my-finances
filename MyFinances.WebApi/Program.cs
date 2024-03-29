using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFinances.WebApi.Models;
using MyFinances.WebApi.Models.Domains;
using MyFinances.WebApi.Models.Repositories;
using MyFinances.WebApi.Models.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
    //    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});


builder.Services.AddDbContext<MyFinancesContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyFinancesContext")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddScoped<IOperationRepository, OperationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
