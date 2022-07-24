using Kameyo.Core.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Company : BaseEntity, IHasDomainEvent
    {
        public Company()
        {
            Subsidiaries = new HashSet<Subsidiary>();
        }

        [Column(Order = 1)]
        public Guid? CatalogTypeId { get; set; }
        [Column(Order = 2)]
        public string? NumberId { get; set; }
        [Column(Order = 3)]
        public string Name { get; set; } = null!;
        [Column(Order = 4)]
        public Guid? CatalogRegionCountryId { get; set; }
        [Column(Order = 5)]
        public Guid? CatalogRegionStateId { get; set; }
        [Column(Order = 6)]
        public Guid? CatalogRegionCityId { get; set; }
        [Column(Order = 7)]
        public string? Address { get; set; }

        public virtual ICollection<Subsidiary> Subsidiaries { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
