using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImageSliderApp.Models;
using Microsoft.EntityFrameworkCore;


namespace ImageSliderApp.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var templates = await _context.Templates.ToListAsync();
        return View(templates ?? new List<Template>());
    }

    // public IActionResult Slider()
    // {
    //     ViewBag.HideSidebar = true; 
    //     var model = new ImageModel();
    //     return View(model); 
    // }

    public async Task<IActionResult> Slider(int roomId)
{
    // Haal templates op die aan de geselecteerde room zijn gekoppeld
    var roomTemplates = await _context.RoomTemplates
        .Include(rt => rt.Template)
        .Where(rt => rt.RoomID == roomId)
        .ToListAsync();

    return View(roomTemplates);
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
