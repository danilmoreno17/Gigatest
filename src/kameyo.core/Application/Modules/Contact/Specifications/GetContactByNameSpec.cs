using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Contact.Specifications
{
    public class GetContactByNameSpec : Specification<Domain.Entities.Contact>
    {
        public GetContactByNameSpec(string name)
        {
            Query
                .Where(x => x.Names == name && x.Active);
        }
    }
}
