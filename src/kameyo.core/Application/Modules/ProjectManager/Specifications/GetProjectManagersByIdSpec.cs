using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.ProjectManager.Specifications
{
    public class GetProjectManagersByIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectManager>
    {
        public GetProjectManagersByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
