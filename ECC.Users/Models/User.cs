using ECC.Shared.Models;

namespace ECC.Models
{
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}