namespace BookStore.Domain
{
    public class Book : Entity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ushort? Pages { get; set; }
        public int Price { get; set; }
        public byte? Discount { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
        public virtual ICollection<BookTag>? BookTags { get; set; }
    }
}
