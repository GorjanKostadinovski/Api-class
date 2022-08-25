
using Microsoft.AspNetCore.Mvc;
using MovieAppWorkShop.Contracts;
using MovieAppWorkShop.Contracts.Services;
using MovieAppWorkShop.Database;



namespace MovieAppWorkShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovieByIdDto([FromRoute] int id)
        {
            GetMovieByIdDTO? movieDTO = await _movieService.GetMoviesAsync(id);


            if (movieDTO == null)
            {
                return NotFound();
            }

            return Ok(movieDTO);
        }





        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddNewMovie([FromBody] GetMovieByIdDTO addMovieDTO)
        {
            await _movieService.CreateMoviesAsync(addMovieDTO);
            return Ok();
        }

        [HttpDelete("DeleteMovie")]
        public async Task<IActionResult> RemoveMovieById(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return Ok();
        }

        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovieById(int id, [FromBody] GetMovieByIdDTO updateMovie)
        {
            await _movieService.UpdateMovieAsync(id, updateMovie);
            return Ok();
        }

    }
}
