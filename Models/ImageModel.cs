using System.IO;

namespace ImageSliderApp.Models
{
    public class ImageModel
    {
        public List<string> ImagePaths { get; set; }

        public ImageModel()
        {
            // Pad naar de map met afbeeldingen in de wwwroot-map
            string imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            // Controleer of de directory bestaat
            if (Directory.Exists(imagesDirectory))
            {
                // Haal alle jpg-, png- en jpeg-bestanden op
                ImagePaths = Directory.GetFiles(imagesDirectory)
                    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".jpeg"))
                    .Select(path => $"/images/{Path.GetFileName(path)}") // URL-pad voor de afbeeldingen
                    .ToList();
            }
            else
            {
                ImagePaths = new List<string>();
            }
        }
    }
}
