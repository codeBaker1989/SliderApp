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

    public DbSet<Overlay> Overlays { get; set; }
    public DbSet<Template> Templates { get; set; }
    
    public DbSet<RoomTemplate> RoomTemplates { get; set; } 


   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Room>()
        .Property(r => r.RoomName)
        .HasMaxLength(255); 

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

       modelBuilder.Entity<Overlay>()
        .HasOne(o => o.Template)
        .WithMany(t => t.Overlays)
        .HasForeignKey(o => o.TemplateID)
        .OnDelete(DeleteBehavior.Cascade); 

}
}

}
