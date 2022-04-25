namespace ECC.Shared.Requests.Contracts.EmergencyCodeRequestDtos
{
    public class CreateEmergencyCodeRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CodeId { get; set; }
        public string ReporterName { get; set; }
        public int ReporterExtension { get; set; }
        public string Location { get; set; }
        public string ActivatedAt { get; set; }
        public string ClearedAt { get; set; }
    }
}
