using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Queries
{
    public class GetProjectTasksPaginationQueryHandler : IRequestHandler<GetProjectTasksPaginationQueryRequest, ResultPaginated<ProjectTasksDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectTasksPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<ProjectTasksDtoResponse>> Handle(GetProjectTasksPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetProjectTasksPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<ProjectTasksDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var projectTasks = await _dbContext.ProjectTasks
                .Where(x => x.Active)
                .Select(x => ProjectTaskMapping.MapToProjectTasksDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return projectTasks;
        }
    }
}
