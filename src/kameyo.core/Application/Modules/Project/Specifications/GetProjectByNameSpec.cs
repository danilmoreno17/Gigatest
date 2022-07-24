using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Project.Specifications
{
    public class GetProjectByNameSpec : Specification<Domain.Entities.Project>
    {
        public GetProjectByNameSpec(string name)
        {
            Query
                .Where(x => x.Name == name && x.Active);
        }
    }
}
