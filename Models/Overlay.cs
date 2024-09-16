namespace ImageSliderApp.Models
{
    public class Overlay
    {
        public int OverlayID { get; set; }
        public string Content { get; set; }
        public string Position { get; set; }

        // Foreign Key naar het Template
        public int TemplateID { get; set; }
        public Template Template { get; set; }
    }
}
