namespace ImageSliderApp.Models
{
public class Room
{
    public int RoomID { get; set; }
    public string? RoomName { get; set; }
    public ICollection<RoomTemplate>? RoomTemplates { get; set; }  // Relatie naar RoomTemplates
}


}
