namespace BookStore.Application.TagApp
{
    public class CreateTagDto
    {
        [Required, StringLength(30)]
        public string? Title { get; set; }
    }
}
