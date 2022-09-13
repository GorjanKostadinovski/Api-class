
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAppWorkShop.Contracts;
using MovieAppWorkShop.Contracts.DTOs.UserDtos;
using MovieAppWorkShop.Contracts.Services;
using MovieAppWorkShop.Database;



namespace MovieAppWorkShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class MovieController : ControllerBase
    {
        public readonly IMovieService _movieService;
        public readonly IUserServices _userServices;

        public MovieController(IMovieService movieService,IUserServices userServices)
        {
            _movieService = movieService;
            _userServices = userServices;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null)
            {
                return BadRequest();
            }

            _userServices.RegisterUser(registerUserDto);

            return Ok(registerUserDto);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            return Ok(await _userServices.LoginUser(loginUserDto));
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
