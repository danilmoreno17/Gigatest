using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Queries
{
    public class GetTaskActivitiesPaginationQueryHandler : IRequestHandler<GetTaskActivitiesPaginationQueryRequest, ResultPaginated<TaskActivitiesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetTaskActivitiesPaginationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultPaginated<TaskActivitiesDtoResponse>> Handle(GetTaskActivitiesPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetTaskActivitiesPaginationQueryValidator()
                .Validate(request);
            if (!validationResult.IsValid)
            {
                return ResultPaginated<TaskActivitiesDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var taskActivities = await _dbContext.TaskActivities
                .Where(x => x.Active)
                .Select(x => TaskActivityMapping.MapToTaskActivitiesDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return taskActivities;
        }
    }
}
