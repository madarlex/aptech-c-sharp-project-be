
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(connectionStrings));

builder.Services.AddCors();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials());

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.Run();
