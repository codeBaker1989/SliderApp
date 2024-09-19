using Microsoft.EntityFrameworkCore;
using ImageSliderApp.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

//pp.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapControllerRoute(
    name: "showroom",
    pattern: "showroom/{id:int}",
    defaults: new { controller = "Room", action = "Details" }
);

app.MapControllerRoute(
    name: "internal",
    pattern: "internal",
    defaults: new { controller = "Room", action = "Internal" }
);

app.MapControllerRoute(
    name: "external",
    pattern: "external",
    defaults: new { controller = "Room", action = "External" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
