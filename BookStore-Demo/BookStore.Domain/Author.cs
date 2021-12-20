namespace BookStore.Domain
{
    public class Author : BaseEntity, IEntityTypeConfiguration<Author>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
