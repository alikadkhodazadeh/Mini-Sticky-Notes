namespace BookStore.Infrastructure.Mappings
{
    public class BookAuthorConfigure : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder
                 .HasKey(p => new { p.BookId, p.AuthorId });

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
