using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Kameyo.Core.Application.Modules.Catalog.Specifications
{
    public class GetCatalogsByParentIdSpecs : Specification<Kameyo.Core.Domain.Entities.Catalog>
    {
        public GetCatalogsByParentIdSpecs(string catalogParentId) 
        {
            if (catalogParentId.Equals("NULL"))
            {
                Query
                    .Where(x => x.ParentId == null);
            }
            else 
            {
                Query
                   .Where(x => x.ParentId.ToString().Equals(catalogParentId));
            }
        }
    }
}
