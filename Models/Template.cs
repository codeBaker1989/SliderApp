namespace ImageSliderApp.Models
{
    public class Template
    {
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string TemplateImagePath { get; set; }

        // Navigation property for many-to-many relationship with Hall via HallTemplate
        public ICollection<HallTemplate> HallTemplates { get; set; }
    }
}
