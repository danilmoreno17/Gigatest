using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Response;
using Kameyo.Core.Application.Modules.EmployeeExperience.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Queries
{
    public class GetEmployeeExperienceQueryHandler : IRequestHandler<GetEmployeeExperienceQueryRequest, Result<EmployeeExperiencesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_EMPLOYEEID = "EMPLOYEEID";

        public GetEmployeeExperienceQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<EmployeeExperiencesDtoResponse>> Handle(GetEmployeeExperienceQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var employeeExperiences = await _dbContext.EmployeeExperiences
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => EmployeeExperienceMapping.MapToEmployeeExperienceDTO(x))
                .ToListAsync(cancellationToken);
            if (employeeExperiences == null) return Result<EmployeeExperiencesDtoResponse>.NotFound();
            return Result<EmployeeExperiencesDtoResponse>.Success(employeeExperiences);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.EmployeeExperience> GetSpecification(GetEmployeeExperienceQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.EmployeeExperience> specification = new GetEmployeeExperienceByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_EMPLOYEEID)
            {
                specification = new GetEmployeeExperiencesByEmployeeIdSpec(request.Value);
            }
            return specification;
        }
    }
}
