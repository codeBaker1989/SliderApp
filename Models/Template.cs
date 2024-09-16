namespace ImageSliderApp.Models
{
    public class Template
    {
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string TemplateImagePath { get; set; }

        // Een template kan meerdere overlays hebben
        public List<Overlay> Overlays { get; set; }
    }
}
