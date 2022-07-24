using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectResource.Queries
{
    public class GetProjectResourcesPaginationQueryHandler : IRequestHandler<GetProjectResourcesPaginationQueryRequest, ResultPaginated<ProjectResourcesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectResourcesPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<ProjectResourcesDtoResponse>> Handle(GetProjectResourcesPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetProjectResourcesPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<ProjectResourcesDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var projectTasks = await _dbContext.ProjectResources
                .Where(x => x.Active)
                .Select(x => ProjectResourceMapping.MapToProjectResourceDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return projectTasks;
        }
    }
}
