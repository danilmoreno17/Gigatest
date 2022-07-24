using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Contact.Specifications
{
    public class GetContactByIdSpec : Specification<Domain.Entities.Contact>
    {
        public GetContactByIdSpec(string contactId)
        {
            Query
                .Where(x => x.Id.ToString() == contactId);
        }
    }
}
