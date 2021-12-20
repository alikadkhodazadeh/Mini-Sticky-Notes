using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Domain
{
    public class BookAuthor : IBaseEntity, IEntityTypeConfiguration<BookAuthor>
    {
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }

        public Book? Book { get; set; }
        public Author? Author { get; set; }

        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder
                .HasKey(P => new { BookId, AuthorId });

            builder
                .HasOne(p => p.Book)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(f => f.BookId);

            builder
                .HasOne(p => p.Author)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(f => f.BookId);
        }
    }
}
