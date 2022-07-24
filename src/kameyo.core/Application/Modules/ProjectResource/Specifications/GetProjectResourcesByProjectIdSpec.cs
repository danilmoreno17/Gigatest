using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Specifications
{
    public class GetProjectResourcesByProjectIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectResource>
    {
        public GetProjectResourcesByProjectIdSpec(string projectId)
        {
            Query
                .Include(x => x.Employee)
                .Where(x => x.ProjectId.ToString() == projectId && x.Active);
        }
    }
}
