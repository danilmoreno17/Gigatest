using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Specifications
{
    public class GetSubsidiariesByNameSpec: Specification<Kameyo.Core.Domain.Entities.Subsidiary>
    {
        public GetSubsidiariesByNameSpec(string name) 
        { 
            Query
                .Where(x => x.Name == name && x.Active);
        }
    }
}
