using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.Project.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Project.Queries
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQueryRequest, Result<ProjectDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_CUSTOMERID = "CUSTOMERID";

        public GetProjectQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ProjectDtoResponse>> Handle(GetProjectQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {

            var specification = GetSpecification(request);
            var projects = await _context.Projects
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ProjectMapping.MapToProjectDTO(x))
                .ToListAsync(cancellationToken);

                if (projects == null) return Result<ProjectDtoResponse>.NotFound();

            return Result<ProjectDtoResponse>.Success(projects);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private ISpecification<Domain.Entities.Project> GetSpecification(GetProjectQueryRequest request)
        {
            ISpecification<Domain.Entities.Project> specification = new GetProjectsByIdSpec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetProjectByNameSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_CUSTOMERID) 
            {
                specification = new GetProjectsByCustomerIdSpec(request.Value);
            }
            return specification;
        }
    }
}
