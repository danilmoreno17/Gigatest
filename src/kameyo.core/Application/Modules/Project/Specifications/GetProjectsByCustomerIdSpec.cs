using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Project.Specifications
{
    public class GetProjectsByCustomerIdSpec : Specification<Kameyo.Core.Domain.Entities.Project>
    {
        public GetProjectsByCustomerIdSpec(string customerId) 
        {
            Query
                .Include(x => x.Customer)
                .Where(x => x.CustomerId.ToString() == customerId && x.Active);
        }
    }
}
