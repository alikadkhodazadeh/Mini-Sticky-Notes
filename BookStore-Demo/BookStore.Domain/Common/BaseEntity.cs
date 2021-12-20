namespace BookStore.Domain.Common
{
    public abstract class BaseEntity<TKey> : IBaseEntity where TKey : struct
    {
        public BaseEntity()
        {
            IsDelete = false;
        }
        public bool IsDelete { get; set; }
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
