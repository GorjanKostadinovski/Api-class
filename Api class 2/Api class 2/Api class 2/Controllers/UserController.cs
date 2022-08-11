using Api_class_2.DTOs;
using Api_class_2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_class_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("{firstName}")]
        public ActionResult<User> GetUserByFirstName(string firstName)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());

            if (userDb == null)
            {
                return NotFound();
            }

            return Ok(userDb);
        }

        [HttpGet("getUserWithIdDTO")]
        public IActionResult FindUserById([FromQuery] GetUserByIdDTO getUserById)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == getUserById.Id);

            if (userDb == null)
            {
                return NotFound();
            }

            return Ok(userDb);
        }

        [HttpPost("UserDto")]
        public IActionResult CreateNewUser([FromBody] CreateUserDTO createUserDTO)
        {
            User newUser = new User();
            newUser.Id = createUserDTO.Id;
            newUser.FirstName = createUserDTO.FirstName;
            newUser.LastName = createUserDTO.LastName;
            newUser.Username = createUserDTO.Username;
            newUser.Password = createUserDTO.Password;

            StaticDb.Users.Add(newUser);
            return Ok();
        }

        [HttpDelete("user/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == id);

            if (userDb == null)
            {
                return NotFound();
            }

            StaticDb.Users.Remove(userDb);

            return Ok();
        }

        [HttpPut("update/user")]
        public IActionResult UpdateUser([FromBody] CreateUserDTO updateUserDTO)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == updateUserDTO.Id);

            if (userDb is null)
            {
                return NotFound();
            }

            userDb.FirstName = updateUserDTO.FirstName;
            userDb.LastName = updateUserDTO.LastName;
            userDb.Username = updateUserDTO.Username;
            userDb.Password = updateUserDTO.Password;

            return Ok();

        }
    }
}
