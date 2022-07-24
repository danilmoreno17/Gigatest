using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class ProjectHourBank : BaseEntity, IHasDomainEvent
    {
        
        public Guid ProjectId { get; set; }
        public Guid HourBankId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual HourBank HourBank { get; set; } = null!;
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
