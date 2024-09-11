using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImageSliderApp.Models;

namespace ImageSliderApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

     public IActionResult Index()
    {
        return View();
    }

    public IActionResult Slider()
    {
        ViewBag.HideSidebar = true; 
        var model = new ImageModel();
        return View(model); 
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
