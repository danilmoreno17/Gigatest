using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Specifications
{
    public class GetTaskActivitiesByProjectIdSpec : Specification<Kameyo.Core.Domain.Entities.TaskActivity>
    {
        public GetTaskActivitiesByProjectIdSpec(string projectId)
        {
            Query
                .Include(x => x.ProjectTask)
                .Where(x => x.ProjectTask.ProjectId.ToString() == projectId && x.Active);
        }
    }
}
