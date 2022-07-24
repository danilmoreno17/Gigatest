using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class EmployeeAward : BaseEntity, IHasDomainEvent
    {
        public Guid EmployeeId { get; set; }
        public string Institution { get; set; }
        public string? Description { get; set; }
        public DateTime? AwardDate { get; set; }
        public virtual Employee Employee { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
