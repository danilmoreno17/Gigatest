using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Contact.Specifications
{
    public class GetContactsByParentIdSpecs : Specification<Kameyo.Core.Domain.Entities.Contact>
    {
        public GetContactsByParentIdSpecs(string contactParentId)
        {
            if (contactParentId.Equals("NULL"))
            {
                Query
                .Where(x => x.ParentId == null);
            }
            else
            {
                Query
                    .Where(x => x.ParentId.ToString().Equals(contactParentId));
            }

        }
    }
}
