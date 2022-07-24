using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Specifications
{
    public class GetEmployeeExperiencesByEmployeeIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeExperience>
    {
        public GetEmployeeExperiencesByEmployeeIdSpec(string employeeId)
        {
            Query
                .Where(x => x.EmployeeId.ToString() == employeeId);
        }
    }
}
