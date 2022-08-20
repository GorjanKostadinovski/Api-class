using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Domain.Database.Seeds;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Models;
using MovieAppWorkShop.Storage.Database;

namespace MovieAppWorkShop.Database
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
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
