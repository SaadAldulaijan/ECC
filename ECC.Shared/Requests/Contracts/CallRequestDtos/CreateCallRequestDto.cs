namespace ECC.Shared.Requests.Contracts.CallRequestDtos
{
    public class CreateCallRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string OnSet { get; set; }
        public int PatientMRN { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public int[] MedicalHistoryIds { get; set; }
    }
}
