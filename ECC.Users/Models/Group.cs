using ECC.Shared.Models;

namespace ECC.Models
{
    public class Group : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}