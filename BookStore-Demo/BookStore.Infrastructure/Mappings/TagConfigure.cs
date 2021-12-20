namespace BookStore.Infrastructure.Mappings
{
    public class TagConfigure : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
