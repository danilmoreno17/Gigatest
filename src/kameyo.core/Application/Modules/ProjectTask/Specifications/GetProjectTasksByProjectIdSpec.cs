using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Specifications
{
    public class GetProjectTasksByProjectIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectTask>
    {
        public GetProjectTasksByProjectIdSpec(string projectTId)
        {
            Query
                .Where(x => x.ProjectId.ToString() == projectTId && x.Active);
        }
    }
}
