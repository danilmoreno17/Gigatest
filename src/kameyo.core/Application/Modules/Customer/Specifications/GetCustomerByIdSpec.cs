using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Customer.Specifications
{
    public class GetCustomerByIdSpec : Specification<Domain.Entities.Customer>
    {
        public GetCustomerByIdSpec(string customerId) 
        {
            Query
                .Include(x => x.Projects.Where(z => z.Active))
                .Include(x => x.HourBanks.Where(z => z.Active))
                .Include(x => x.Contacts.Where(z => z.Active))
                .Where(x => x.Id.ToString() == customerId);
        }
    }
}
