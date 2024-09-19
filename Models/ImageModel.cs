using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImageSliderApp.Models
{
    public class ImageModel
{
    public List<string> ImagePaths { get; set; }
    public string Room { get; set; }

    public ImageModel(string room)
    {
        Room = room;

        // Dynamisch de map selecteren op basis van de opgegeven ruimte
        string imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", room);

        if (Directory.Exists(imagesDirectory))
        {
            // Haal de afbeeldingen uit de juiste map (per ruimte)
            ImagePaths = Directory.GetFiles(imagesDirectory)
                .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".jpeg"))
                .Select(path => $"/images/{room}/{Path.GetFileName(path)}") // URL-pad voor de afbeeldingen
                .ToList();
        }
        else
        {
            ImagePaths = new List<string>(); // Lege lijst als de map niet bestaat
        }
    }
}
}
