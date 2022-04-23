using ECC.Shared.Models;

namespace ECC.Models
{
    public class Permission : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}