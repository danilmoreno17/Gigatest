using Kameyo.Core.Application.Modules.Employee.Dtos.Response;

namespace Kameyo.Core.Application.Modules.Employee.Mapping
{
    public class EmployeeMapping
    {
        public EmployeeMapping()
        {

        }

        public static EmployeeDtoResponse MapToEmployeeDTO(Domain.Entities.Employee entity)
        {
            return new EmployeeDtoResponse
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                SubsidiaryId = entity.SubsidiaryId,
                Names = entity.Names,
                LastName = entity.LastName,
                FullName = entity.Names + ' ' + entity.LastName,
                CatalogAreaId = entity.CatalogAreaId,
                CatalogDepartmentId = entity.CatalogDepartmentId,
                CatalogCostCenterId = entity.CatalogCostCenterId,
                CatalogPositionId = entity.CatalogPositionId,
                CatalogCurrencyId = entity.CatalogCurrencyId,
                CatalogEmployeeTypeId = entity.CatalogEmployeeTypeId,
                CostHour = entity.CostHour,
                PhoneOffice = entity.PhoneOffice,
                PhoneMobile = entity.PhoneMobile,
                PhoneOfficeExt = entity.PhoneOfficeExt,
                CalculateFactor = entity.CalculateFactor,
            };
        }

        //public void UpdateUserEntity(Domain.Entities.Employee entity, EmployeeUpdateDtoRequest dto)
        //{            
        //    entity.FirstName = dto.FirstName;
        //    entity.LastName = dto.LastName;
        //}
    }
}
