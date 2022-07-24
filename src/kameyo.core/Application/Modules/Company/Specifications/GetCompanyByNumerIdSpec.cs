using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Company.Specifications
{
    public class GetCompanyByNumerIdSpec : Specification<Domain.Entities.Company>
    {
        public GetCompanyByNumerIdSpec(string numberId)
        {
            Query
                .Where(x => x.NumberId == numberId && x.Active);
        }
    }
}
