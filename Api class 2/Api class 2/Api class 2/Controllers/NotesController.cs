using Api_class_2.DTOs;
using Api_class_2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_class_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet("queryParameters")]
        public ActionResult<Note> GetNoteByQueryId(int id)
        {
            Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == id);

            if (noteDb == null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status200OK, noteDb);
        }

        [HttpPost("NoteDto")]
        public IActionResult CreateNewNote([FromBody] CreateNoteDTO noteDto)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == noteDto.UserId);

            Note newNote = new Note();
            newNote.Id = noteDto.Id;
            newNote.Text = noteDto.Text;
            newNote.Color = noteDto.Color;
            newNote.User = userDb;
            
            

            StaticDb.Notes.Add(newNote);
            return Ok();
        }

        [HttpDelete("note/{id}")]
        public IActionResult DeleteNOteById(int id)
        {
            Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == id);

            if (noteDb == null)
            {
                return NotFound();
            }

            StaticDb.Notes.Remove(noteDb);

            return Ok();
        }
    }
}
