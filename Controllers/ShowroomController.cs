using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImageSliderApp.Models;

namespace ImageSliderApp.Controllers;

public class RoomController : Controller
{
    private readonly ApplicationDbContext _context;

    public RoomController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Route voor het toevoegen van een nieuwe room
    [HttpPost]
    public async Task<IActionResult> AddRoom(Room room)
    {
        if (ModelState.IsValid)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(room);
    }

    // Route voor het verwijderen van een room
    [HttpPost]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room != null)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}

