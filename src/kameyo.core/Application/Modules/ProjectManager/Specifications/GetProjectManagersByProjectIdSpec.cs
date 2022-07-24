using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.ProjectManager.Specifications
{
    public class GetProjectManagersByProjectIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectManager>
    {
        public GetProjectManagersByProjectIdSpec(string projectId)
        {
            Query
                .Where(x => x.ProjectId.ToString() == projectId && x.Active);
        }
    }
}
