namespace BookStore.Domain
{
    public class Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderType Gender { get; set; }
    }
}
