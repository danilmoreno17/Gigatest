using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.TaskActivity.Specifications
{
    public class GetTaskActivitiesByIdSpec : Specification<Kameyo.Core.Domain.Entities.TaskActivity>
    {
        public GetTaskActivitiesByIdSpec(string taskActivityId)
        {
            Query
                .Where(x => x.Id.ToString() == taskActivityId);
        }
    }
}
