using Api_class_2.Entities;

namespace Api_class_2.DTOs
{
    public class CreateNoteDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Color { get; set; }

        public int UserId { get; set; }
    }
}
