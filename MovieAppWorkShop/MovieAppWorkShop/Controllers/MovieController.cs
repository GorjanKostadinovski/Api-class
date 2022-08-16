using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAppWorkShop.DTOs;
using MovieAppWorkShop.Entities;

namespace MovieAppWorkShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("getMovieWithDto")]
        public IActionResult GetMovieByIdDto([FromQuery] GetMovieByIdDTO movieIdDto)
        {
            Movie movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == movieIdDto.Id);

            if (movieDb == null)
            {
                return NotFound();
            }

            return Ok(movieDb);
        }

        [HttpGet("getAllMovies")]

        public IActionResult GetAllMovies()
        {
            List<Movie> movieDb = StaticDb.Movies;
            foreach(Movie movie in movieDb)
            {
                movie.Genre.ToString();
            }

            return Ok(movieDb);
        }

        [HttpGet("getMovieWithGenreDto")]
        public IActionResult GetMovieByGenreDto([FromQuery] GetMovieByGenreDTO movieGenreDto)
        {
            List<Movie> movieDb = StaticDb.Movies.Where(x => x.Genre == movieGenreDto.Genre).ToList();
            foreach(Movie movie in movieDb)
            {
                movie.Genre.ToString();
            }
            if (movieDb == null)
            {
                return NotFound();
            }
            

            return Ok(movieDb);
        }

        [HttpPost("AddMovie")]
        public IActionResult AddNewMovie([FromBody] CreateMovieDTO addMovieDTO)
        {
            Movie newMovie = new Movie();
            newMovie.Id = addMovieDTO.Id;
            newMovie.Title = addMovieDTO.Title;
            newMovie.Year = addMovieDTO.Year;
            newMovie.Genre = addMovieDTO.Genre;
            newMovie.Description = addMovieDTO.Description;

            StaticDb.Movies.Add(newMovie);
            return Ok();
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult RemoveMovieById(int id)
        {
            Movie movie = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            StaticDb.Movies.Remove(movie);
            return Ok();
        }
    }
}
