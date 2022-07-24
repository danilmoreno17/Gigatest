using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Customer.Specifications
{
    public class GetCustomerByNameSpec : Specification<Domain.Entities.Customer>
    {
        public GetCustomerByNameSpec(string name)
        {
            Query
                .Where(x => x.Name == name && x.Active);
        }
    }
}
