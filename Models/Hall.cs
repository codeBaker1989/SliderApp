namespace ImageSliderApp.Models
{
    public class Hall
    {
        public int HallID { get; set; }
        public string HallName { get; set; }

        // Navigation property for many-to-many relationship with Template via HallTemplate
        public ICollection<HallTemplate> HallTemplates { get; set; }
    }
}
