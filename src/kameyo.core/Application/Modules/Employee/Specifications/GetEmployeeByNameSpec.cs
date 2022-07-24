using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Employee.Specifications
{
    public class GetEmployeeByNameSpec : Specification<Domain.Entities.Employee>
    {
        public GetEmployeeByNameSpec(string name)
        {
            Query
                .Where(x => x.Names == name && x.Active);
        }
    }
}
