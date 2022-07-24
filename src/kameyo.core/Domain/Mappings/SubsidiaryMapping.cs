using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class SubsidiaryMapping
    {
        public SubsidiaryMapping()
        {

        }

        public static SubsidiariesDtoResponse MapToSubsidiaryDTO(Kameyo.Core.Domain.Entities.Subsidiary entity)
        {
            return new SubsidiariesDtoResponse
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CatalogTypeId = entity.CatalogTypeId,
                NumberId = entity.NumberId,
                Name = entity.Name,
                CatalogRegionCityId = entity.CatalogRegionCityId,
                CatalogRegionCountryId = entity.CatalogRegionCountryId,
                CatalogRegionStateId = entity.CatalogRegionStateId,
                Address = entity.Address,
                PctPartIndrctCommissions = entity.PctPartIndrctCommissions,
            };
        }


    }
}
