using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Rule : BaseEntity, IHasDomainEvent
    {
        
        public Guid? SubsidiaryId { get; set; }
        public string? Name { get; set; }
        public string? Formula { get; set; }

        public virtual Subsidiary? Subsidiary { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
