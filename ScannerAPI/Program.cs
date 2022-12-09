using Microsoft.EntityFrameworkCore;
using ScannerAPI;
using ScannerAPI.Entities;
using ScannerAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScannerDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddDbContext<ScannerDbContext>();
builder.Services.AddScoped<ScannerDbContext>();
builder.Services.AddScoped<ScannerSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IScannerService, ScannerService>();
var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ScannerSeeder>();
seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
