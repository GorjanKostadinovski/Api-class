using MovieAppWorkShop.Entities;

namespace MovieAppWorkShop
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie{Id = 1, Title = "Titanic", Year = 1997,Genre = Enums.MovieGenre.Tragedy, Description = "ThE story Of the singking of the cruiseShip Named The Titanic"},
            new Movie{Id = 2,Title = "The GodFather",Year= 1972,Genre = Enums.MovieGenre.Thriller,Description = "Italian Mafia"},
            new Movie{Id = 3,Title = "Avengers:Endgame",Year = 2019,Genre = Enums.MovieGenre.Fantasy,Description = "Superhero Movie"},
            new Movie{Id = 4,Title = "RushHour",Year = 1998,Genre = Enums.MovieGenre.Comedy,Description = "Jackie Chan action comedy"},
            new Movie{Id = 5,Title= "Avatar",Year = 2009,Genre = Enums.MovieGenre.Fantasy,Description = "Movie about blue aliens"}
        
        };

        public static List<Director> Directors = new List<Director>
        {
            new Director{ FirstName = "a",LastName = "b", }
        };


    }
}
