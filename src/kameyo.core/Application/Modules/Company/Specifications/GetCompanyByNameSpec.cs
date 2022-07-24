using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Company.Specifications
{
    public class GetCompanyByNameSpec : Specification<Domain.Entities.Company>
    {
        public GetCompanyByNameSpec(string name)
        {
            Query
                .Where(x => x.Name == name && x.Active);
        }
    }
}
