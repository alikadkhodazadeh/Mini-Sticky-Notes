namespace StickyNotes.DTOs
{
    public class UpdateNoteDto
    {
        public UpdateNoteDto()
        {
            LastModifyDate = DateTime.Now;
        }

        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
