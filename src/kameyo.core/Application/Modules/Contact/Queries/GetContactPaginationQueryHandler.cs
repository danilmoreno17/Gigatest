using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;
using Kameyo.Core.Application.Modules.Contact.Dtos.Response;
using Kameyo.Core.Application.Modules.Contact.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Contact.Queries
{
    public class GetContactPaginationQueryHandler : IRequestHandler<GetContactPaginationQueryRequest, ResultPaginated<ContactDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetContactPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultPaginated<ContactDtoResponse>> Handle(GetContactPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetContactPaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<ContactDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var Contact = await _context.Contacts
                .Where(x => x.Active)
                .Select(x => ContactMapping.MapToContactDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Contact;
        }


    }
}
