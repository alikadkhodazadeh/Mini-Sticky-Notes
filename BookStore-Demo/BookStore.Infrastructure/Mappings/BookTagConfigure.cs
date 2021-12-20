namespace BookStore.Infrastructure.Mappings
{
    public class BookTagConfigure : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder
                 .HasKey(p => new { p.BookId, p.TagId });

            builder
                .HasOne(p => p.Book)
                .WithMany(t => t.BookTags)
                .HasForeignKey(f => f.BookId);

            builder
                .HasOne(p => p.Tag)
                .WithMany(t => t.BookTags)
                .HasForeignKey(f => f.TagId);
        }
    }
}
