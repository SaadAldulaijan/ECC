namespace ECC.Requests.Models.CallRequestModels
{
    public class CallRequestMedicalHistory
    {
        public int CallRequestId { get; set; }
        public CallRequestModel CallRequest { get; set; }
        public int MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
    }
}
