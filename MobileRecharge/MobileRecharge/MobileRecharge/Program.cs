
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Converters;
using MobileRecharge.Models;
using MobileRecharge.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionStrings));

builder.Services.AddCors();
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers().AddJsonOptions(option => {
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials());

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.Run();
