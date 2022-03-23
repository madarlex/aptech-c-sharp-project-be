
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Models;
using MobileRecharge.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

    
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddScoped<PrepaidService, PrepaidServiceImpl>();
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionStrings));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials());

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.Run();
