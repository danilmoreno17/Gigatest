using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Project.Queries
{
    public class GetProjectPaginationQueryHandler : IRequestHandler<GetProjectPaginationQueryRequest, ResultPaginated<ProjectDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetProjectPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultPaginated<ProjectDtoResponse>> Handle(GetProjectPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetProjectPaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<ProjectDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var Project = await _context.Projects
                .Where(x => x.Active)
                .Select(x => ProjectMapping.MapToProjectDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Project;
        }


    }
}
