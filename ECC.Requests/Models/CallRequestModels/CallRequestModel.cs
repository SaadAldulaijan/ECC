using ECC.Shared.Requests.Contracts.SharedRequests;

namespace ECC.Requests.Models.CallRequestModels
{
    public class CallRequestModel : Request
    {
        public string OnSet { get; set; }
        public int PatientMRN { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public virtual ICollection<CallRequestMedicalHistory> CallRequestMedicalHistories { get; set; }

    }
}
