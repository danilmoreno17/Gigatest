using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Company.Dtos.Request
{
    public class UpdateCompanyCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? CatalogTypeId { get; set; } = default!;
        public string? NumberId { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public Guid? CatalogRegionCountryId { get; set; } = default!;
        public Guid? CatalogRegionStateId { get; set; } = default!;
        public Guid? CatalogRegionCityId { get; set; } = default!;
        public string? Address { get; set; } = default!;

    }
}
