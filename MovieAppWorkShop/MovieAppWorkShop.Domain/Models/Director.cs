using MovieAppWorkShop.Domain.Models;

namespace MovieAppWorkShop.Models
{
    public class Director
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Movie> DirectedMovies { get; set; }

        public List<string> Awards { get; set; }
    }
}
