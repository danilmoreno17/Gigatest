using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Employee.Specifications
{
    public class GetEmployeesBySubsidiaryIdSpec : Specification<Kameyo.Core.Domain.Entities.Employee>
    {
        public GetEmployeesBySubsidiaryIdSpec(string subsidiaryId)
        {
            Query
                .Where(x => x.SubsidiaryId.ToString() == subsidiaryId);
        }
    }
}
