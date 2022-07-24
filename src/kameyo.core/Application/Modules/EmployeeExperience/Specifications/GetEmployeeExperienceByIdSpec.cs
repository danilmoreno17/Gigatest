using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Specifications
{
    public class GetEmployeeExperienceByIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeExperience>
    {
        public GetEmployeeExperienceByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
