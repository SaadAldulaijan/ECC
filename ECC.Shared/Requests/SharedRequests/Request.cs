using ECC.Shared.Models;

namespace ECC.Shared.Requests.Contracts.SharedRequests
{
    public class Request : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestType RequestType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
