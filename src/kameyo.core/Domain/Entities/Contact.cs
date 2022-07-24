using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Contact : BaseEntity, IHasDomainEvent
    {
        
        public Guid? ParentId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Names { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Area { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneOffice { get; set; }
        public string? PhoneOfficeExt { get; set; }
        public string? PhoneMobile { get; set; }

        public virtual Customer? Customer { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
