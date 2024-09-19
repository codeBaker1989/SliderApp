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
         var templates = await _context.Templates
                                  .Include(t => t.Overlays)  // Zorg ervoor dat de overlays worden opgehaald
                                  .ToListAsync();

    return View(templates); 
    }

    // public IActionResult Slider()
    // {
    //     ViewBag.HideSidebar = true; 
    //     var model = new ImageModel();
    //     return View(model); 
    // }

        // Actie om sliders per ruimte te tonen
    public IActionResult Slider(string room)
{
     if (string.IsNullOrEmpty(room))
            {
                return NotFound("Room not specified.");
            }

            // Haal het Template op met de bijbehorende overlays voor de opgegeven room
            var template = _context.Templates
                                   .Include(t => t.Overlays)  // Haal de overlays op die bij dit template horen
                                   .FirstOrDefault(t => t.Room == room);

            if (template == null)
            {
                return NotFound("Template not found for the specified room.");
            }

            // Geef het template door aan de view
            return View(template);
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
