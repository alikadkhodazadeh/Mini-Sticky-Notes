namespace BookStore.Infrastructure.Mappings
{
    public class CategoryConfigure : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
