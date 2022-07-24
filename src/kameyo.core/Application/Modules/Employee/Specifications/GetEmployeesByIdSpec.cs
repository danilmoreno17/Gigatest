using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Employee.Specifications
{
    public class GetEmployeesByIdSpec : Specification<Kameyo.Core.Domain.Entities.Employee>
    {
        public GetEmployeesByIdSpec(string employeeId) 
        {
            Query
                .Where(x => x.Id.ToString() == employeeId);
        }
    }
}
