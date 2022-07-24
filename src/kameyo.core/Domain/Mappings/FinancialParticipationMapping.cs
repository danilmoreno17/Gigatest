using Kameyo.Core.Application.Modules.Employee.Mapping;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Kameyo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class FinancialParticipationMapping
    {
        public FinancialParticipationMapping() { 
        }
        public static FinancialParticipationDtoResponse MapToFinancialParticipationDTO(FinancialParticipation entity)
        {
            return new FinancialParticipationDtoResponse
            {
                Id = entity.Id,
                CatalogDiscretionaryTypeId = entity.CatalogDiscretionaryTypeId,
                Description = entity.Description,
                EmployeeId = entity.EmployeeId,
                Month = entity.Month,
                Year = entity.Year,
                Status = entity.Status,
                Type = entity.Type,
                Value = entity.Value,
                Employee = EmployeeMapping.MapToEmployeeDTO(entity.Employee)
            };
        }
    }
}
