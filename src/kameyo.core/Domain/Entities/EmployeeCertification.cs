using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class EmployeeCertification : BaseEntity, IHasDomainEvent
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public DateTime? EmissionDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public virtual Employee Employee { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
