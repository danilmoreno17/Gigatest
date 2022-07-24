using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Response;
using Kameyo.Core.Application.Modules.EmployeeAward.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Queries
{
    public class GetEmployeeAwardQueryHandler : IRequestHandler<GetEmployeeAwardQueryRequest, Result<EmployeeAwardDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_EMPLOYEEID = "EMPLOYEEID";

        public GetEmployeeAwardQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<EmployeeAwardDtoResponse>> Handle(GetEmployeeAwardQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var employeeAwards = await _dbContext.EmployeeAwards
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => EmployeeAwardMapping.MapToEmployeeAwardDTO(x))
                .ToListAsync(cancellationToken);
            if (employeeAwards == null) return Result<EmployeeAwardDtoResponse>.NotFound();
            return Result<EmployeeAwardDtoResponse>.Success(employeeAwards);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.EmployeeAward> GetSpecification(GetEmployeeAwardQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.EmployeeAward> specification = new GetEmployeeAwardsByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_EMPLOYEEID)
            {
                specification = new GetEmployeeAwardsByEmployeeIdSpec(request.Value);
            }
            return specification;
        }
    }
}
