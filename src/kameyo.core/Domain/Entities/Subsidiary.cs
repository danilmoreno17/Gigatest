using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Subsidiary : BaseEntity, IHasDomainEvent
    {
        public Subsidiary()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Rules = new HashSet<Rule>();
        }

        
        public Guid? CompanyId { get; set; }
        public Guid? CatalogTypeId { get; set; }
        public string? NumberId { get; set; }
        public string Name { get; set; } = null!;
        public Guid? CatalogRegionCountryId { get; set; }
        public Guid? CatalogRegionStateId { get; set; }
        public Guid? CatalogRegionCityId { get; set; }
        public string? Address { get; set; }
        public decimal? PctPartIndrctCommissions { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
