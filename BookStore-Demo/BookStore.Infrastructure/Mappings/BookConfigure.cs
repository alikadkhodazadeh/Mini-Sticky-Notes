namespace BookStore.Infrastructure.Mappings
{
    public class BookConfigure: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Category)
                .WithMany(t => t.Books)
                .HasForeignKey(f => f.CategoryId);
        }
    }
}
