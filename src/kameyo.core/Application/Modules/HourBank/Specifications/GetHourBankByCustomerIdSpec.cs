using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Specifications
{
    public class GetHourBankByCustomerIdSpec : Specification<Kameyo.Core.Domain.Entities.HourBank>
    {
        public GetHourBankByCustomerIdSpec(string customerId)
        {
            Query
                .Where(x => x.CustomerId.ToString() == customerId && x.Active);
        }
    }
}
