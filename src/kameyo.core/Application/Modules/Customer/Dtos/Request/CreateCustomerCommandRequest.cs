using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Customer.Dtos.Request
{
    public class CreateCustomerCommandRequest : IRequest<Result<string>>
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
    }
}
