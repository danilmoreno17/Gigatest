using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Contact.Specifications
{
    public class GetContactByCustomerIdSpec : Specification<Domain.Entities.Contact>
    {
        public GetContactByCustomerIdSpec(string customerId)
        {
            Query
                .Where(x => x.CustomerId.ToString() == customerId && x.Active);
        }
    }
}
