using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using Kameyo.Core.Application.Modules.Employee.Mapping;
using Kameyo.Core.Application.Modules.Employee.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Employee.Queries
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQueryRequest, Result<EmployeeDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_SUBSIDIARYID = "SUBSIDIARYID";
        private readonly string FILTER_FIELD_PARENTID = "PARENTID";

        public GetEmployeeQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<EmployeeDtoResponse>> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var Employee = await _context.Employees
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => EmployeeMapping.MapToEmployeeDTO(x))
                .ToListAsync(cancellationToken: cancellationToken);

            if (Employee == null) return Result<EmployeeDtoResponse>.NotFound();

            return Result<EmployeeDtoResponse>.Success(Employee);

            // return Result<EmployeeDtoResponse>.Success(new List<EmployeeDtoResponse>() { Employee });
        }

        private ISpecification<Domain.Entities.Employee> GetSpecification(GetEmployeeQueryRequest request)
        {
            ISpecification<Domain.Entities.Employee> specification = new GetEmployeesByIdSpec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetEmployeeByNameSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_PARENTID)
            {
                specification = new GetEmployeeByParentIdSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_SUBSIDIARYID)
            {
                specification = new GetEmployeesBySubsidiaryIdSpec(request.Value);
            }
            return specification;
        }
    }
}
