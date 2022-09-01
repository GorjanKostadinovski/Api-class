using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Models;

namespace MovieAppWorkShop.Domain.Database.Seeds
{
    public class MovieSeed
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie{Id = 1, Title = "Titanic", Year = 1997,Genre = Enums.MovieGenre.Tragedy, Description = "ThE story Of the singking of the cruiseShip Named The Titanic" ,UserId = 1 },
            new Movie{Id = 2,Title = "The GodFather",Year= 1972,Genre = Enums.MovieGenre.Thriller,Description = "Italian Mafia" ,UserId = 1},
            new Movie{Id = 3,Title = "Avengers:Endgame",Year = 2019,Genre = Enums.MovieGenre.Fantasy,Description = "Superhero Movie",UserId = 1},
            new Movie{Id = 4,Title = "RushHour",Year = 1998,Genre = Enums.MovieGenre.Comedy,Description = "Jackie Chan action comedy",UserId = 2},
            new Movie{Id = 5,Title= "Avatar",Year = 2009,Genre = Enums.MovieGenre.Fantasy,Description = "Movie about blue aliens",UserId = 2}

        };
    }
}
