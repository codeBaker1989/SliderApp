using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImageSliderApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ImageSliderApp.Controllers;

public class TemplateController : Controller
{
    private readonly ApplicationDbContext _context;

    public TemplateController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Template/AddTemplate
   public IActionResult AddTemplate()
    {
        return View("~/Views/Template/AddTemplate.cshtml");
    }

        public IActionResult AddOverlay(int templateId)
        {
            // Maak een nieuwe overlay en koppel het aan het templateId
            var overlay = new Overlay { TemplateID = templateId };
            return View(overlay);
        }

        // POST: /Template/AddOverlay
[HttpPost]
public async Task<IActionResult> AddOverlay(Overlay overlay)
{
    if (ModelState.IsValid)
    {
        // Voeg de overlay toe aan de database
        _context.Overlays.Add(overlay);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }

    // Als het model niet geldig is, kun je foutmeldingen loggen voor debuggen
    var errors = ModelState.Values.SelectMany(v => v.Errors);
    foreach (var error in errors)
    {
        Console.WriteLine(error.ErrorMessage); // Log de foutmeldingen
    }

    // Als er een fout is, toon de overlay opnieuw in de view
    return View(overlay);
}



// GET: /Template/AssignToRoom/{templateId}
public IActionResult AssignToRoom(int templateId)
{
    var roomTemplate = new RoomTemplate { TemplateID = templateId };
    ViewBag.Rooms = new SelectList(_context.Rooms, "RoomID", "RoomName");  // Dropdown met rooms
    return View(roomTemplate);
}

// POST: /Template/AssignToRoom
[HttpPost]
public async Task<IActionResult> AssignToRoom(RoomTemplate roomTemplate)
{
    if (ModelState.IsValid)
    {
        _context.RoomTemplates.Add(roomTemplate);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }
    return View(roomTemplate);
}

  // GET: /Template/ViewTemplate/{templateId}// GET: /Template/ViewTemplate/{templateId}
public async Task<IActionResult> ViewTemplate(int templateId)
{
    var template = await _context.Templates
        .Include(t => t.Overlays)  // Haal de overlays op
        .FirstOrDefaultAsync(t => t.TemplateID == templateId);

    if (template == null)
    {
        return NotFound();
    }

    return View(template);
}



}

