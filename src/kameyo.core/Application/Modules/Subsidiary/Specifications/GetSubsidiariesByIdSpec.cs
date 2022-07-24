using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Specifications
{
    public class GetSubsidiariesByIdSpec : Specification<Kameyo.Core.Domain.Entities.Subsidiary>
    {
        public GetSubsidiariesByIdSpec(string subsidiaryId) 
        {
            Query
                .Where(x => x.Id.ToString() == subsidiaryId);
        }
    }
}
