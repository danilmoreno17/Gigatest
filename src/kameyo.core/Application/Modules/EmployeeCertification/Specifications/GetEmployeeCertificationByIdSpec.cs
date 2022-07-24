using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Specifications
{
    public class GetEmployeeCertificationByIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeCertification>
    {
        public GetEmployeeCertificationByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
