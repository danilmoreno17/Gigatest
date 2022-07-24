using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;

using Kameyo.Core.Application.Modules.ProjectReport.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Queries
{
    public class GetProjectReportQueryHandler : IRequestHandler<GetProjectReportQueryRequest, Result<ProjectReportDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        public GetProjectReportQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ProjectReportDtoResponse>> Handle(GetProjectReportQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var ProjectReport = await _context.ProjectReport
                .Include(x=> x.Project)
                .ThenInclude(x=> x.Customer)
                .Include(x=> x.ProjectReportDetails)
                .ThenInclude(x=> x.TaskActivity)           
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ProjectReportMapping.MapToProjectReportDTO(x))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (ProjectReport == null) return Result<ProjectReportDtoResponse>.NotFound();

            return Result<ProjectReportDtoResponse>.Success(new List<ProjectReportDtoResponse>() { ProjectReport });
        }

        private ISpecification<Domain.Entities.ProjectReport> GetSpecification(GetProjectReportQueryRequest request)
        {
            ISpecification<Domain.Entities.ProjectReport> specification = new GetProjectReportByIdSepec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetProjectReportByIdSepec(request.Value);
            }
            return specification;
        }
    }
}
