using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public class MenuRole : BaseEntity, IHasDomainEvent
    {
        public Guid? UserId { get; set; }= null;
        public Guid RoleId { get; set; }        
        public Guid CatalogMenuId { get; set; }
        public virtual Catalog CatalogMenu { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
