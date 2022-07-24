using Kameyo.Core.Application.Modules.Contact.Mapping;
using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Domain.Mappings;

namespace Kameyo.Core.Application.Modules.Customer.Mapping
{
    public class CustomerMapping
    {
        public CustomerMapping()
        {

        }

        public static CustomerDtoResponse MapToCustomerDTO(Domain.Entities.Customer entity)
        {
            return new CustomerDtoResponse
            {
                Id = entity.Id,
                SubsidiaryId = entity.SubsidiaryId,
                CatalogTypeId = entity.CatalogTypeId,
                NumberId = entity.NumberId,
                Name = entity.Name,
                CatalogRegionCountryId = entity.CatalogRegionCountryId,
                CatalogRegionStateId = entity.CatalogRegionStateId,
                CatalogRegionCityId = entity.CatalogRegionCityId,
                Address = entity.Address,
                Phone = entity.Phone,
                CatalogIndustryTypeId = entity.CatalogIndustryTypeId,
                CatalogIndustrySubTypeId = entity.CatalogIndustrySubTypeId,
                CatalogCurrencyId = entity.CatalogCurrencyId,
                Deadlinebilling = entity.Deadlinebilling,
                CostHourMen = entity.CostHourMen,
                Active = entity.Active,
                Projects = entity.Projects != null ? ProjectMapping.MapListToProjectsDTO(entity.Projects) : new List<Project.Dtos.Response.ProjectDtoResponse>(),
                HourBanks = entity.HourBanks != null ? HourBankMapping.MapListToHourBanksDTO(entity.HourBanks) : new List<HourBank.Dtos.Response.HourBanksDtoResponse>(),
                Contacts = entity.Contacts != null ? ContactMapping.MapListToContactsDTO(entity.Contacts) : new List<Contact.Dtos.Response.ContactDtoResponse>(),
            };
        }
    }
}
