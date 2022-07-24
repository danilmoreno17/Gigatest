using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;
using Kameyo.Core.Application.Modules.Contact.Dtos.Response;
using Kameyo.Core.Application.Modules.Contact.Mapping;
using Kameyo.Core.Application.Modules.Contact.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Contact.Queries
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQueryRequest, Result<ContactDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_PARENTID = "PARENTID";
        private readonly string FILTER_FIELD_CUSTOMERID = "CUSTOMERID";
        private readonly string FILTER_FIELD_PARENT_CUSTOMERID = "PARENTCUSTOMERID";

        public GetContactQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ContactDtoResponse>> Handle(GetContactQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var contacts = await _context.Contacts
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ContactMapping.MapToContactDTO(x))
                .ToListAsync(cancellationToken);

            if (contacts == null) return Result<ContactDtoResponse>.NotFound();

            return Result<ContactDtoResponse>.Success(contacts);
        }

        private ISpecification<Domain.Entities.Contact> GetSpecification(GetContactQueryRequest request)
        {
            ISpecification<Domain.Entities.Contact> specification = new GetContactByIdSpec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetContactByNameSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_PARENTID)
            {
                specification = new GetContactsByParentIdSpecs(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_CUSTOMERID)
            {
                specification = new GetContactByCustomerIdSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_PARENT_CUSTOMERID) 
            {
                specification = new GetContactParentByCustomerIdSpec(request.Value);
            }

            return specification;
        }
    }
}
