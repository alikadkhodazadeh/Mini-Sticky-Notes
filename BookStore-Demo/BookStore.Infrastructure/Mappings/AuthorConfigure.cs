namespace BookStore.Infrastructure.Mappings
{
    public class AuthorConfigure : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
