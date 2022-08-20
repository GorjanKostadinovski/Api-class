using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Database.Seeds;
using MovieAppWorkShop.Models;

namespace MovieAppWorkShop.Database
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                        .HasData(MovieSeed.Movies);
        }
    }

}
