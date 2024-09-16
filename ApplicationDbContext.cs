using Microsoft.EntityFrameworkCore;

namespace ImageSliderApp.Models
{
   public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }          // Hernoemd van Hall naar Room
    public DbSet<Template> Templates { get; set; }
    
    public DbSet<Overlay> Overlays { get; set; }
    public DbSet<RoomTemplate> RoomTemplates { get; set; }  // Hernoemd van HallTemplate naar RoomTemplate


   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Room>()
        .Property(r => r.RoomName)
        .HasMaxLength(255);  // Stel een specifieke lengte in voor RoomName

    modelBuilder.Entity<RoomTemplate>()
        .HasKey(rt => new { rt.RoomID, rt.TemplateID });

    modelBuilder.Entity<RoomTemplate>()
        .HasOne(rt => rt.Room)
        .WithMany(r => r.RoomTemplates)
        .HasForeignKey(rt => rt.RoomID);

    modelBuilder.Entity<RoomTemplate>()
        .HasOne(rt => rt.Template)
        .WithMany(t => t.RoomTemplates)
        .HasForeignKey(rt => rt.TemplateID);
}
}

}
