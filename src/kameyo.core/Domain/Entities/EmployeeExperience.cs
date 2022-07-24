using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class EmployeeExperience : BaseEntity, IHasDomainEvent
    {
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string? Type { get; set; }
        public string? CompanyCity { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string? Description { get; set; }
        public virtual Employee Employee { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
