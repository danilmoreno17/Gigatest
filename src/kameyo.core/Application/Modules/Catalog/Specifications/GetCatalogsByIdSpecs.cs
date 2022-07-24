using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Catalog.Specifications
{
    public class GetCatalogsByIdSpecs : Specification<Kameyo.Core.Domain.Entities.Catalog>
    {
        public GetCatalogsByIdSpecs(string catalogId) 
        {
            Query
                .Where(x => x.Id.ToString() == catalogId);
        }
    }
}
