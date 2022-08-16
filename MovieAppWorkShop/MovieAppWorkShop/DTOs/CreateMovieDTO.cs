using MovieAppWorkShop.Enums;

namespace MovieAppWorkShop.DTOs
{
    public class CreateMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public MovieGenre Genre {get; set; }

    }
}
