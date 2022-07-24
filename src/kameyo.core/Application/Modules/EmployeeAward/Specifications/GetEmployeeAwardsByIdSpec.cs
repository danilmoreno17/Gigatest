using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Specifications
{
    public class GetEmployeeAwardsByIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeAward>
    {
        public GetEmployeeAwardsByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
