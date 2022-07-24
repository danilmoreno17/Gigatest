using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.ProjectResource.Specifications
{
    public class GetProjectResourcesByEmployeeIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectResource>
    {
        public GetProjectResourcesByEmployeeIdSpec(string employeeId)
        {
            Query
                .Where(x => x.EmployeeId.ToString() == employeeId);
        }
    }
}
