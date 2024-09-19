using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImageSliderApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


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
            var overlay = new Overlay { TemplateID = templateId };
            return View(overlay);
        }
        // POST: /Template/AddOverlay
 [HttpPost]
        public async Task<IActionResult> AddOverlay(int templateId, string content, string position, string room)
        {
            // Controleer of het template bestaat
            var template = await _context.Templates.FirstOrDefaultAsync(t => t.TemplateID == templateId);

            if (template == null)
            {
                ModelState.AddModelError("", "The specified template does not exist.");
                return View();
            }

            // Maak de overlay aan met de gekozen Room
            var overlay = new Overlay
            {
                Content = content,
                Position = position,
                Room = room,  // Sla de gekozen ruimte op
                TemplateID = template.TemplateID
            };

            if (ModelState.IsValid)
            {
                _context.Overlays.Add(overlay);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewTemplate", new { templateId = template.TemplateID });
            }

            return View(overlay);
        }





// GET: /Template/AssignToRoom/{templateId}
// public IActionResult AssignToRoom(int templateId)
// {
//     var roomTemplate = new RoomTemplate { TemplateID = templateId };
//     ViewBag.Rooms = new SelectList(_context.Rooms, "RoomID", "RoomName");  // Dropdown met rooms
//     return View(roomTemplate);
// }

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

