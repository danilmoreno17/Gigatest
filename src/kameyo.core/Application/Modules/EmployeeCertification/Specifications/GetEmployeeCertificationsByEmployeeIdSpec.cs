using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Specifications
{
    public class GetEmployeeCertificationsByEmployeeIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeCertification>
    {
        public GetEmployeeCertificationsByEmployeeIdSpec(string employeeId)
        {
            Query
                .Where(x => x.EmployeeId.ToString() == employeeId);
        }
    }
}
