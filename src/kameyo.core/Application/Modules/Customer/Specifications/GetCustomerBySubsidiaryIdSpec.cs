using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Customer.Specifications
{
    public class GetCustomerBySubsidiaryIdSpec : Specification<Domain.Entities.Customer>
    {
        public GetCustomerBySubsidiaryIdSpec(string subsidiaryId)
        {
            Query.Where(x => x.SubsidiaryId.ToString() == subsidiaryId);
        }
    }
}
