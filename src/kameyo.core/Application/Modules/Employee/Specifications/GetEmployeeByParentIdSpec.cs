using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Employee.Specifications
{
    public class GetEmployeeByParentIdSpec : Specification<Kameyo.Core.Domain.Entities.Employee>
    {
        public GetEmployeeByParentIdSpec(string employeeParentId)
        {
            if (employeeParentId.Equals("NULL"))
            {
                Query
                .Where(x => x.ParentId == null);
            }
            else
            {
                Query
                    .Where(x => x.ParentId.ToString().Equals(employeeParentId));
            }

        }
    }
}
