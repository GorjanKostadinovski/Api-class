using MovieAppWorkShop.Contracts;
using MovieAppWorkShop.Domain.Models;

namespace MovieAppWorkShop.Services.Mappers
{
    public static class MoviesMapper
    {
        public static GetMovieByIdDTO ToMovieDto(this Movie movie)
        {
            return new GetMovieByIdDTO()
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Description = movie.Description
            };
        }

        public static Movie ToMovie(this GetMovieByIdDTO getMovieByIdDTO)
        {
            return new Movie()
            {
                Title = getMovieByIdDTO.Title,
                Year = getMovieByIdDTO.Year,
                Description = getMovieByIdDTO.Description
            };
        }
    }
}
