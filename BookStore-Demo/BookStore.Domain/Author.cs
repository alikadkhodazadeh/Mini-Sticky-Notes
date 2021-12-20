namespace BookStore.Domain
{
    public class Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
