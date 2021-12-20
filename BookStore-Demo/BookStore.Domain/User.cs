namespace BookStore.Domain
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public User()
        {
            IsActive = true;
        }

        public bool IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
