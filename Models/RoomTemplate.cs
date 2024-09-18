namespace ImageSliderApp.Models
{
    public class RoomTemplate
    {
        public int RoomID { get; set; }
        public Room Room { get; set; } = new Room();
        public Template Template { get; set; } = new Template();

        public int TemplateID { get; set; }

    }
}
