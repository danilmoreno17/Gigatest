using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using Kameyo.Core.Application.Modules.Employee.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Employee.Queries
{
    public class GetEmployeePaginationQueryHandler : IRequestHandler<GetEmployeePaginationQueryRequest, ResultPaginated<EmployeeDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetEmployeePaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultPaginated<EmployeeDtoResponse>> Handle(GetEmployeePaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetEmployeePaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<EmployeeDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var Employee = await _context.Employees
                .Where(x => x.Active)
                .Select(x => EmployeeMapping.MapToEmployeeDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Employee;
        }


    }
}
