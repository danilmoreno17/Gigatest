using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class ProjectResource : BaseEntity, IHasDomainEvent
    {
        
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? CatalogEmployeeRolId { get; set; }
        public decimal CalculateFactorEmployee { get; set; }
        public decimal CalculateFactorProject { get; set; }
        public decimal ParticipationValue { get; set; }
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
