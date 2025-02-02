using Microsoft.EntityFrameworkCore;
using MovieTrackerProject.Domain.Entities;
namespace MovieTrackerProject.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rate> Rates { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.User)
                .WithMany(u => u.Movies)
                .HasForeignKey(m => m.UserId)
                .IsRequired(false);

         
            modelBuilder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(r => r.UserId)
                .IsRequired(false); 

         
            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Rates)
                .HasForeignKey(r => r.MovieId)
                .IsRequired(false); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
