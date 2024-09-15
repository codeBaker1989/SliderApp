using Microsoft.EntityFrameworkCore;
using ImageSliderApp.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
