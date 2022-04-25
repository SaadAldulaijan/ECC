using ECC.Shared.Requests.Contracts.SharedRequests;

namespace ECC.Shared.Requests.Contracts.EmergencyCodeRequestDtos
{
    public class GetEmergencyCodeRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestType RequestType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CodeName { get; set; }
        public bool CodeHasClear { get; set; }
        public bool CodeHasPhases { get; set; }
        public int CodeId { get; set; }
        public string ReporterName { get; set; }
        public int ReporterExtension { get; set; }
        public string Location { get; set; }
        public DateTime ActivatedAt { get; set; }
        public DateTime? ClearedAt { get; set; }
        public CodePhase? Phase { get; set; }
    }
}
