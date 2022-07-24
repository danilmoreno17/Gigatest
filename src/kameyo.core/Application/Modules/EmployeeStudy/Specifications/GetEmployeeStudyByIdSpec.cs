using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Specifications
{
    public class GetEmployeeStudyByIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeStudy>
    {
        public GetEmployeeStudyByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
