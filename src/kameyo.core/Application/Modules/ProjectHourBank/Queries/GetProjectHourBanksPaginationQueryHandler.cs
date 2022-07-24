using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Queries
{
    public class GetProjectHourBanksPaginationQueryHandler : IRequestHandler<GetProjectHourBanksPaginationQueryRequest, ResultPaginated<ProjectHourBanksDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectHourBanksPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<ProjectHourBanksDtoResponse>> Handle(GetProjectHourBanksPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetProjectHourBanksPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<ProjectHourBanksDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var projectHourBanks = await _dbContext.ProjectHourBanks
                .Where(x => x.Active)
                .Select(x => ProjectHourBankMapping.MapToProjectHourBankDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return projectHourBanks;
        }
    }
}
