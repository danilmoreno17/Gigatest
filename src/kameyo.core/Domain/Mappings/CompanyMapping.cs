using Kameyo.Core.Application.Modules.Company.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class CompanyMapping
    {
        public CompanyMapping()
        {

        }

        public static CompanyDtoResponse MapToCompanyDTO(Kameyo.Core.Domain.Entities.Company entity)
        {
            return new CompanyDtoResponse
            {
                CatalogTypeId = entity.CatalogTypeId,
                CatalogRegionCountryId = entity.CatalogRegionCountryId,
                CatalogRegionCityId = entity.CatalogRegionCityId,
                CatalogRegionStateId = entity.CatalogRegionStateId,
                Address = entity.Address,
                Id = entity.Id,
                Name = entity.Name,
                NumberId = entity.NumberId
            };
        }

        //public void UpdateUserEntity(Domain.Entities.Company entity, CompanyUpdateDtoRequest dto)
        //{            
        //    entity.FirstName = dto.FirstName;
        //    entity.LastName = dto.LastName;
        //}
    }
}
