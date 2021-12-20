namespace BookStore.Domain.Common
{
    public abstract class Entity<TEntityKey, TCreatorKey> : BaseEntity<TEntityKey>
        where TCreatorKey : struct where TEntityKey : struct
    {
        public TCreatorKey? CreatorId { get; set; }

        public User? Creator { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }

    public abstract class Entity : Entity<int, Guid>
    {
    }
}
