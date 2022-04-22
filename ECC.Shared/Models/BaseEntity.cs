namespace ECC.Shared.Models
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool Deleted { get; set; }
    }
}