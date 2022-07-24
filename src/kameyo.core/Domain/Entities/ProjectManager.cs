using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class ProjectManager : BaseEntity, IHasDomainEvent
    {

        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
