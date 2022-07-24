using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Specifications
{
    public class GetProjectHourBanksByIdSpec : Specification<Kameyo.Core.Domain.Entities.ProjectHourBank>
    {
        public GetProjectHourBanksByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
