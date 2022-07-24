using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class EmployeeExperienceMapping
    {
        public EmployeeExperienceMapping()
        {
        }

        public static EmployeeExperiencesDtoResponse MapToEmployeeExperienceDTO(Domain.Entities.EmployeeExperience entity)
        {
            return new EmployeeExperiencesDtoResponse
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Title = entity.Title,
                CompanyName = entity.CompanyName,
                Type = entity.Type,
                CompanyCity = entity.CompanyCity,
                BeginDate = entity.BeginDate,
                FinishDate = entity.FinishDate,
                Description = entity.Description,
            };
        }
    }
}
