using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Specifications
{
    public class GetEmployeeStudyByEmployeeIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeStudy>
    {
        public GetEmployeeStudyByEmployeeIdSpec(string employeeId)
        {
            Query
                .Where(x => x.EmployeeId.ToString() == employeeId);
        }
    }
}
