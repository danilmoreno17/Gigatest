using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Company.Specifications
{
    public class GetCompanyByIdSpec : Specification<Domain.Entities.Company>
    {
        public GetCompanyByIdSpec(string companyId) 
        {
            Query
                .Where(x => x.Id.ToString() == companyId);
        }
    }
}
