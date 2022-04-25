using ECC.Shared.Requests.Contracts.SharedRequests;

namespace ECC.Shared.Requests.Contracts.CallRequestDtos
{
    public class GetCallRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestType RequestType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OnSet { get; set; }
        public int PatientMRN { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public IList<MedicalHistoryDto> MedicalHistories { get; set; }
    }
}
