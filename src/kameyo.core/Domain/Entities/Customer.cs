using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class Customer : BaseEntity, IHasDomainEvent
    {
        public Customer()
        {
            Contacts = new HashSet<Contact>();
            HourBanks = new HashSet<HourBank>();            
            Projects = new HashSet<Project>();
        }
        
        public Guid? SubsidiaryId { get; set; }
        public Guid? CatalogTypeId { get; set; }
        public string? NumberId { get; set; }
        public string? Name { get; set; }
        public Guid? CatalogRegionCountryId { get; set; }
        public Guid? CatalogRegionStateId { get; set; }
        public Guid? CatalogRegionCityId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public Guid? CatalogIndustryTypeId { get; set; }
        public Guid? CatalogIndustrySubTypeId { get; set; }
        public Guid? CatalogCurrencyId { get; set; }
        public int? Deadlinebilling { get; set; }
        public decimal CostHourMen { get; set; } = 0;
        public virtual Subsidiary? Subsidiary { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<HourBank> HourBanks { get; set; }        
        public virtual ICollection<Project> Projects { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
