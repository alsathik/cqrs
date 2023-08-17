using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattren.CommandQuery;
using RepositoryDesignPattren.Models;
using RepositoryDesignPattren.Repository;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SampdbContext>(options => options.UseSqlServer(config.GetConnectionString("Default")));

builder.Services.AddScoped<IRepoCustomer, CutomerRepo>();
builder.Services.AddScoped<CommandQueryHandler>();
builder.Services.AddScoped<CustomerCommandHandler>();
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
