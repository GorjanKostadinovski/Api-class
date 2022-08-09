using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        [Route("GetNote/{guid:guid}")]
        public IActionResult GetNote([FromRoute] Guid guid ,[FromQuery] int id)
        {
            if(id <= 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"request was denied, the id was not found");
            }
            return StatusCode(StatusCodes.Status200OK, $"request was successful, id: {id}, GUID: {guid}");
        }

        [HttpGet("{id}")]
        public IActionResult GetNote2(int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"request was denied, the id was not found");
            }
            return StatusCode(StatusCodes.Status200OK, $"request was successful, id: {id}");
        }

        [HttpPost]
        [Route("InsertNote/{id:int}")]
        public IActionResult InsertNote([FromRoute] int id, [FromQuery] string name, [FromBody] CreateNoteRequest request)
        {
            
            return Ok(request.ToString() +"Id: "+ id +" Name: "+ name);
        }
        


    }
}
