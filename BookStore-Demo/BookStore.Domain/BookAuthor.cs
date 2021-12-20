using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Domain
{
    public class BookAuthor : IBaseEntity
    {
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }

        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }
}
