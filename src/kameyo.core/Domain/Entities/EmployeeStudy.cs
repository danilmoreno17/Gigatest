using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class EmployeeStudy : BaseEntity, IHasDomainEvent
    {
        public Guid EmployeeId { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string? FieldKnowledge { get; set; }
        public DateTime? EmissionDate { get; set; }
        public virtual Employee Employee { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
