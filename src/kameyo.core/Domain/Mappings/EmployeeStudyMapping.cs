using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class EmployeeStudyMapping
    {
        public EmployeeStudyMapping()
        {
        }

        public static EmployeeStudiesDtoResponse MapToEmployeeStudyDTO(Domain.Entities.EmployeeStudy entity)
        {
            return new EmployeeStudiesDtoResponse
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Institution = entity.Institution,
                Degree = entity.Degree,
                FieldKnowledge = entity.FieldKnowledge,
                EmissionDate = entity.EmissionDate,
            };
        }
    }
}
