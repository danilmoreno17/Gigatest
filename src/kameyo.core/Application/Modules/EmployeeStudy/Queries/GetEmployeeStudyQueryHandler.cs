using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Response;
using Kameyo.Core.Application.Modules.EmployeeStudy.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Queries
{
    public class GetEmployeeStudyQueryHandler : IRequestHandler<GetEmployeeStudyQueryRequest, Result<EmployeeStudiesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_EMPLOYEEID = "EMPLOYEEID";

        public GetEmployeeStudyQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<EmployeeStudiesDtoResponse>> Handle(GetEmployeeStudyQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var employeeStudys = await _dbContext.EmployeeStudies
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => EmployeeStudyMapping.MapToEmployeeStudyDTO(x))
                .ToListAsync(cancellationToken);
            if (employeeStudys == null) return Result<EmployeeStudiesDtoResponse>.NotFound();
            return Result<EmployeeStudiesDtoResponse>.Success(employeeStudys);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.EmployeeStudy> GetSpecification(GetEmployeeStudyQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.EmployeeStudy> specification = new GetEmployeeStudyByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_EMPLOYEEID)
            {
                specification = new GetEmployeeStudyByEmployeeIdSpec(request.Value);
            }
            return specification;
        }
    }
}
