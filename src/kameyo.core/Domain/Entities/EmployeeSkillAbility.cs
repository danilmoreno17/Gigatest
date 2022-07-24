using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class EmployeeSkillAbility : BaseEntity, IHasDomainEvent
    {
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
        public virtual Employee Employee { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
