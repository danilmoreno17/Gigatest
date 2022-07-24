using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Catalog.Specifications
{
    public class GetCatalogsByNameSpec : Specification<Kameyo.Core.Domain.Entities.Catalog>
    {
        public GetCatalogsByNameSpec(string catalogName) 
        {
            Query
                .Where(x => x.Name.Equals(catalogName));
        }
    }
}
