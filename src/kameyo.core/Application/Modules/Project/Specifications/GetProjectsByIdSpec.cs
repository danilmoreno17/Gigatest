using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Project.Specifications
{
    public class GetProjectsByIdSpec : Specification<Kameyo.Core.Domain.Entities.Project>
    {
        public GetProjectsByIdSpec(string projectId)
        {
            Query
                .Include(x=> x.ProjectTasks.Where(z => z.Active))
                .ThenInclude(x => x.TaskActivities.Where(z => z.Active))
                .Include(x=> x.ProjectResources.Where(z => z.Active))
                .ThenInclude(x=> x.Employee)
                .Include(x => x.ProjectHourBanks.Where(z => z.Active))
                .Include(x => x.ProjectManagers.Where(z => z.Active))
                .Include(x => x.Customer)
                .Where(x => x.Id.ToString() == projectId);
        }
    }
}
