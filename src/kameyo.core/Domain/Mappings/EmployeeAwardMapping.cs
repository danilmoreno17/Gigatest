using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class EmployeeAwardMapping
    {
        public EmployeeAwardMapping()
        {
        }

        public static EmployeeAwardDtoResponse MapToEmployeeAwardDTO(Domain.Entities.EmployeeAward entity)
        {
            return new EmployeeAwardDtoResponse
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Institution = entity.Institution,
                Description = entity.Description,
                AwardDate = entity.AwardDate,
            };
        }
    }
}
