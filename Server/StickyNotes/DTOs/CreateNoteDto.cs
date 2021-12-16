namespace StickyNotes.DTOs
{
    public class CreateNoteDto
    {
        public CreateNoteDto()
        {
            CreationDate = DateTime.Now;
            IsDelete = true;
        }
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
