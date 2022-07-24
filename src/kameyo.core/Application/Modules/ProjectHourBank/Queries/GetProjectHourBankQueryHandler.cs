using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectHourBank.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Queries
{
    public class GetProjectHourBankQueryHandler : IRequestHandler<GetProjectHourBankQueryRequest, Result<ProjectHourBanksDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_PROJECTID = "PROJECTID";

        public GetProjectHourBankQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectHourBanksDtoResponse>> Handle(GetProjectHourBankQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var projectHourBanks = await _dbContext.ProjectHourBanks
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ProjectHourBankMapping.MapToProjectHourBankDTO(x))
                .ToListAsync(cancellationToken);
            if (projectHourBanks == null) return Result<ProjectHourBanksDtoResponse>.NotFound();
            return Result<ProjectHourBanksDtoResponse>.Success(projectHourBanks);
        }

        private ISpecification<Kameyo.Core.Domain.Entities.ProjectHourBank> GetSpecification(GetProjectHourBankQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.ProjectHourBank> specification = new GetProjectHourBanksByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_PROJECTID)
            {
                specification = new GetProjectHourBanksByProjectIdSpec(request.Value);
            }
            return specification;
        }
    }
}
