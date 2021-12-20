namespace BookStore.Domain
{
    public class Tag : BaseEntity
    {
        public string? Title { get; set; }

        public virtual ICollection<BookTag>? BookTags { get; set; }
    }
}
