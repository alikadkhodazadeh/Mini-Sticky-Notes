namespace BookStore.Domain
{
    public class Role : IdentityRole<int>, IBaseEntity
    {
        public string? Description { get; set; }
    }
}
