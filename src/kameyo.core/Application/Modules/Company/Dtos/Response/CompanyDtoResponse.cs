namespace Kameyo.Core.Application.Modules.Company.Dtos.Response
{
    public class CompanyDtoResponse
    {
        public Guid Id { get; set; } = default!;
        public Guid? CatalogTypeId { get; set; } = default!;
        public string? NumberId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Guid? CatalogRegionCountryId { get; set; } = default!;
        public Guid? CatalogRegionStateId { get; set; } = default!;
        public Guid? CatalogRegionCityId { get; set; } = default!;
        public string? Address { get; set; } = default!;
        public bool Active { get; set; } = default!;


    }
}
