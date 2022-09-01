using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Domain.Database.Seeds;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Domain.Models.Enums;
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
            modelBuilder.Entity<User>()
                .HasMany(x => x.Movies)
                .WithOne(x => x.FavoritedUsers)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Movie>()
                        .HasData(MovieSeed.Movies);
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Bojan",
                    LastName = "Damchevski",
                    Role = Role.Admin,
                    Password = "Test123!",
                    Username = "Bojandamcevski98"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Mihajlo",
                    LastName = "Dimovski",
                    Role = Role.Admin,
                    Password = "Test123!",
                    Username = "MihajloDimovski96"
                });
        }
    }

}
