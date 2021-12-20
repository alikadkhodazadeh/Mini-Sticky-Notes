namespace BookStore.Domain
{
    public class Category : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category? ParentCategory { get; set; }
        public virtual ICollection<Category>? ChildCategories { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
