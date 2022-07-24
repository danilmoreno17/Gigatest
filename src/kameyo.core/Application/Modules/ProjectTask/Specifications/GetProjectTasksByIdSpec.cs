using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Specifications
{
    public class GetProjectTasksByIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectTask>
    {
        public GetProjectTasksByIdSpec(string projectTaskId)
        {
            Query
                .Include(x => x.TaskActivities.Where(z => z.Active))
                .Include(x => x.Project)
                .Where(x => x.Id.ToString() == projectTaskId);
        }
    }
}
