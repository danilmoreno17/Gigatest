using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Customer.Specifications
{
    public class GetCustomerByNumberIdSpec : Specification<Domain.Entities.Customer>
    {
        public GetCustomerByNumberIdSpec(string numberId)
        {
            Query
                .Where(x => x.NumberId == numberId && x.Active);
        }
    }
}
