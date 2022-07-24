using Kameyo.Core.Domain.Common;
using System.ComponentModel;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Catalog : BaseEntity, IHasDomainEvent
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; }        
        public string? Description { get; set; } = null!;
        public string Value { get; set; }
        public string? Value1 { get; set; } = null!;
        public string? Value2 { get; set; } = null!;

        [DefaultValue(0)]
        public int Order { get; set; } = 0;
        [DefaultValue(false)]
        public bool IsSystemOwner { get; set; } = false;
        public int? Status { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
