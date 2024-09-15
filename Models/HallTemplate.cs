namespace ImageSliderApp.Models
{
    public class HallTemplate
    {
        public int HallID { get; set; }
        public Hall Hall { get; set; }  // Verwijzing naar de Hall-class, niet dupliceren

        public int TemplateID { get; set; }
        public Template Template { get; set; }
    }
}
