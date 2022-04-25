using ECC.Shared.Requests.Contracts.EmergencyCodeRequestDtos;
using ECC.Shared.Requests.Contracts.SharedRequests;

namespace ECC.Requests.Models.EmergencyCodeModels
{
    public class EmergencyCodeRequest : Request
    {
        public Code Code { get; set; }
        public int CodeId { get; set; }
        public string ReporterName { get; set; }
        public int ReporterExtension { get; set; }
        public string Location { get; set; }
        public DateTime ActivatedAt { get; set; }
        public DateTime? ClearedAt { get; set; }
        public CodePhase? Phase { get; set; }
    }
}
