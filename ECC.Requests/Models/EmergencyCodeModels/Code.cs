using ECC.Shared.Models;

namespace ECC.Requests.Models.EmergencyCodeModels
{
    public class Code : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool HasClear { get; set; }
        public bool HasPhases { get; set; }
    }
}
