namespace ImageSliderApp.Models
{

    public class Overlay
    {
        public int OverlayID { get; set; }          
        public string Content { get; set; }         

        public string Position { get; set; }        

        public int TemplateID { get; set; }        
        public Template Template { get; set; }      

        public string Room { get; set; }            
    
    }

}
