using Api_class_2.DTOs;
using Api_class_2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_class_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {

        [HttpPost("TagDTO")]
        public IActionResult CreateNewTag([FromBody] CreateTagDTO createTagDTO)
        {
            Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == createTagDTO.NoteId);

            if(noteDb == null)
            {
                return NotFound();
            }

            Tag newTag = new Tag();
            newTag.Id = createTagDTO.Id;
            newTag.Name = createTagDTO.Name;
            newTag.Color = createTagDTO.Color;

            noteDb.Tags.Add(newTag);
            return Ok();
        }
    }
}
