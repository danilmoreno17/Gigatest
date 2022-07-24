using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using Kameyo.Core.Application.Modules.Company.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Company.Queries
{
    public class GetCompanyPaginationQueryHandler : IRequestHandler<GetCompanyPaginationQueryRequest, ResultPaginated<CompanyDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetCompanyPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultPaginated<CompanyDtoResponse>> Handle(GetCompanyPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetCompanyPaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<CompanyDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var users = await _context.Companies
                .Where(x => x.Active)
                .Select(x => CompanyMapping.MapToCompanyDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return users;
        }


    }
}
