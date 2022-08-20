
using Microsoft.AspNetCore.Mvc;
using MovieAppWorkShop.Contracts;
using MovieAppWorkShop.Database;



namespace MovieAppWorkShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly MoviesDbContext _moviesDbContext;

        public MovieController(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }
           

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovieByIdDto([FromRoute] int id)
        {
            GetMovieByIdDTO? movieDTO = _moviesDbContext.Movies.Select(x => new GetMovieByIdDTO()
            {
                Id = x.Id,
                Title = x.Title,
                Year = x.Year

            }).SingleOrDefault(x => x.Id == id);

            if (movieDTO == null)
            {
                return NotFound();
            }

            return Ok(movieDTO);
        }

        //[HttpGet("getAllMovies")]

        //public IActionResult GetAllMovies()
        //{
        //    List<Movie> movieDb = StaticDb.Movies;
        //    foreach(Movie movie in movieDb)
        //    {
        //        movie.Genre.ToString();
        //    }

        //    return Ok(movieDb);
        //}

        //[HttpGet("getMovieWithGenreDto")]
        //public IActionResult GetMovieByGenreDto([FromQuery] GetMovieByGenreDTO movieGenreDto)
        //{
        //    List<Movie> movieDb = StaticDb.Movies.Where(x => x.Genre == movieGenreDto.Genre).ToList();
        //    foreach(Movie movie in movieDb)
        //    {
        //        movie.Genre.ToString();
        //    }
        //    if (movieDb == null)
        //    {
        //        return NotFound();
        //    }
            

        //    return Ok(movieDb);
        //}

        //[HttpPost("AddMovie")]
        //public IActionResult AddNewMovie([FromBody] CreateMovieDTO addMovieDTO)
        //{
        //    Movie newMovie = new Movie();
        //    newMovie.Id = addMovieDTO.Id;
        //    newMovie.Title = addMovieDTO.Title;
        //    newMovie.Year = addMovieDTO.Year;
        //    newMovie.Genre = addMovieDTO.Genre;
        //    newMovie.Description = addMovieDTO.Description;

        //    StaticDb.Movies.Add(newMovie);
        //    return Ok();
        //}

        //[HttpDelete("DeleteMovie")]
        //public IActionResult RemoveMovieById(int id)
        //{
        //    Movie movie = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    StaticDb.Movies.Remove(movie);
        //    return Ok();
        //}
    }
}
