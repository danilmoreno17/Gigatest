using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Contact.Specifications
{
    public class GetContactParentByCustomerIdSpec : Specification<Kameyo.Core.Domain.Entities.Contact>
    {
        public GetContactParentByCustomerIdSpec(string customerId)
        {
            Query
                .Where(x => x.ParentId == null && x.CustomerId.ToString()==customerId);
        }
    }
}
