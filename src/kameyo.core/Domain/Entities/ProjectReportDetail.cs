using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class ProjectReportDetail : BaseEntity, IHasDomainEvent
    {        
        public Guid ProjectReportId { get; set; }
        public Guid TaskActivityId { get; set; }

        public System.Nullable<Guid> FinancialParticipationId { get; set; }
        public virtual ProjectReport ProjectReport { get; set; } = null!;
        public string? Observation { get; set; } = null!;
        public virtual TaskActivity TaskActivity { get; set; } = null!;
        public virtual FinancialParticipation FinancialParticipation { get; set; } = null!;

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
