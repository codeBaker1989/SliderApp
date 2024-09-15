using Microsoft.EntityFrameworkCore;

namespace ImageSliderApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<HallTemplate> HallTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between Hall and Template via HallTemplate
            modelBuilder.Entity<HallTemplate>()
                .HasKey(ht => new { ht.HallID, ht.TemplateID }); // Composite key

            modelBuilder.Entity<HallTemplate>()
                .HasOne(ht => ht.Hall)
                .WithMany(h => h.HallTemplates)
                .HasForeignKey(ht => ht.HallID);

            modelBuilder.Entity<HallTemplate>()
                .HasOne(ht => ht.Template)
                .WithMany(t => t.HallTemplates)
                .HasForeignKey(ht => ht.TemplateID);
        }
    }
}
