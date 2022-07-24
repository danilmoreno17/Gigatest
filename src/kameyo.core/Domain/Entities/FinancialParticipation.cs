using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class FinancialParticipation : BaseEntity, IHasDomainEvent
    {
        public FinancialParticipation() {
            Description = String.Empty;
            //Employee = new Employee();
        }
        public Guid EmployeeId { get; set; }
        
        public char Type { get; set; }
        public Guid? CatalogDiscretionaryTypeId { get; set; }
        public decimal Value { get; set; }
        public char Status { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public virtual Employee Employee{get;set;}
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
