using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class ProjectTask : BaseEntity, IHasDomainEvent
    {
        public ProjectTask()
        {
            TaskActivities = new HashSet<TaskActivity>();
        }

        
        public Guid ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CatalogTaskTypeId { get; set; }
        public int? Order { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? DurationHour { get; set; }
        public int? Progress { get; set; }
        public Guid? CatalogTaskStateId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<TaskActivity> TaskActivities { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
