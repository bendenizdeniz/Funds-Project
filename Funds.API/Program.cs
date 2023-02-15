using Funds.Application;
using Funds.Infrastructure;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register Configuration
//ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Initial Database Service
builder.Services.AddDbContext<FundsDbContext>();
//builder.Services.AddDbContext<FundsDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
//b => b.MigrationsAssembly("Funds.API")));

//Dependency Injection
builder.Services.AddTransient<IFundsRepository, FundsRepository>();
builder.Services.AddTransient<IFundsService, FundsService>();

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
