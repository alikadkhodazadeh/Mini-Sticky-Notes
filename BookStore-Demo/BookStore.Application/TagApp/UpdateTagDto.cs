namespace BookStore.Application.TagApp
{
    public class UpdateTagDto : CreateTagDto
    {
        [Required]
        public int? Id { get; set; }
    }
}
