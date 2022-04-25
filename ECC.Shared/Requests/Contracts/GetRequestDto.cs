using ECC.Shared.Requests.Contracts.SharedRequests;

namespace ECC.Shared.Requests.Contracts
{
    public class GetRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestType RequestType { get; set; }
        public int CreatedBy { get; set; }
    }
}
