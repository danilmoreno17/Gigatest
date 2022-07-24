using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.TaskActivity.Specifications
{
    public class GetTaskActivitiesByProjectTaskIdSpec : Specification<Kameyo.Core.Domain.Entities.TaskActivity>
    {
        public GetTaskActivitiesByProjectTaskIdSpec(string projectTaskId)
        {
            Query
                .Where(x => x.ProjectTaskId.ToString() == projectTaskId);
        }
    }
}
