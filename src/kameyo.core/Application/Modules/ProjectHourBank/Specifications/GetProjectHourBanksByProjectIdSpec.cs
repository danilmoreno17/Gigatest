using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Specifications
{
    public class GetProjectHourBanksByProjectIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectHourBank>
    {
        public GetProjectHourBanksByProjectIdSpec(string projectId)
        {
            Query
                .Include(x => x.HourBank)
                .Where(x => x.ProjectId.ToString() == projectId && x.Active);
        }
    }
}
