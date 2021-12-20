namespace BookStore.Domain
{
    public class Role : IdentityRole, IBaseEntity
    {
        public string? Description { get; set; }
    }
}
