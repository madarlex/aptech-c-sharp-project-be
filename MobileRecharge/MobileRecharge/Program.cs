
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Models;
using MobileRecharge.Services;
using System.Text.Json.Serialization;
using MobileRecharge.Converters;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionStrings));
builder.Services.AddControllers().AddJsonOptions(x =>
               {
                   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                   x.JsonSerializerOptions.Converters.Add(new DateConverter());
               });




    
builder.Services.AddCors();

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddScoped<PrepaidService, PrepaidServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<PostpaidService, PostpaidServiceImpl>();
builder.Services.AddScoped<RechargeService, RechargeServiceImpl>();
builder.Services.AddScoped<AboutUsService, AboutUsServiceImpl>();
builder.Services.AddScoped<FeedbackService, FeedbackServiceImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials());

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.Run();
