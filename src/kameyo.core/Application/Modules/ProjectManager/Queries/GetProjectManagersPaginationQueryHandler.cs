using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectManager.Queries
{
    public class GetProjectManagersPaginationQueryHandler : IRequestHandler<GetProjectManagersPaginationQueryRequest, ResultPaginated<ProjectManagersDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectManagersPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<ProjectManagersDtoResponse>> Handle(GetProjectManagersPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetProjectManagersPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<ProjectManagersDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var projectManagers = await _dbContext.ProjectManagers
                .Where(x => x.Active)
                .Select(x => ProjectManagerMapping.MapToProjectManagerDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return projectManagers;
        }
    }
}
