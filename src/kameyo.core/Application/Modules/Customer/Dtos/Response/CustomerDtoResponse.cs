using Kameyo.Core.Application.Modules.Contact.Dtos.Response;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;

namespace Kameyo.Core.Application.Modules.Customer.Dtos
{
    public class CustomerDtoResponse
    {
        public Guid Id { get; set; }
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
        public bool Active { get; set; } = default!;
        public List<ProjectDtoResponse> Projects { get; set; }
        public List<ContactDtoResponse> Contacts { get; set; }
        public List<HourBanksDtoResponse> HourBanks { get; set; }
    }
}
