using ECC.Shared.Models;

namespace ECC.Requests.Models.CallRequestModels
{
    public class MedicalHistory : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<CallRequestMedicalHistory> CallRequestMedicalHistories { get; set; }
    }
}
