using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class EmployeeCertificationMapping
    {
        public EmployeeCertificationMapping()
        {
        }

        public static EmployeeCertificationsDtoResponse MapToEmployeeCertificationDTO(Domain.Entities.EmployeeCertification entity)
        {
            return new EmployeeCertificationsDtoResponse
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Name = entity.Name,
                Institution = entity.Institution,
                EmissionDate = entity.EmissionDate,
                ProductionDate = entity.ProductionDate,
                ExpirationDate = entity.ExpirationDate,
            };
        }
    }
}
