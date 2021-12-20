namespace BookStore.Application.Book
{
    public class CreateDto
    {
        [Required,StringLength(50)]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public ushort? Pages { get; set; }

        [Required]
        public int Price { get; set; }

    }
}
