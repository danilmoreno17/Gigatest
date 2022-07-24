using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Specifications
{
    public class GetProjectResourcesByIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectResource>
    {
        public GetProjectResourcesByIdSpec(string projectResourceId)
        {
            Query
                .Where(x => x.Id.ToString() == projectResourceId);
        }
    }
}
