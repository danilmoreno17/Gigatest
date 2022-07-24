using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Subsidiary.Queries
{
    public class GetSubsidiariesPaginationQueryHandler : IRequestHandler<GetSubsidiariesPaginationQueryRequest, ResultPaginated<SubsidiariesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetSubsidiariesPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<SubsidiariesDtoResponse>> Handle(GetSubsidiariesPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetSubsidiariesPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<SubsidiariesDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var subsidiaries = await _dbContext.Subsidiaries
                .Where(x => x.Active)
                .Select(x => SubsidiaryMapping.MapToSubsidiaryDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return subsidiaries;
        }
    }
}
