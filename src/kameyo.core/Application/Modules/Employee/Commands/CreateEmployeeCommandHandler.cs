using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Commands.Validators;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.Employee.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {

            var EmployeeExits = _context.Employees.All(z => z.Names == request.Names && z.Active);
            if (EmployeeExits)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El empleado ya existe",
                        Name=""
                    }
                });
            }

            /*var validationResult = await new CreateEmployeeCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/


            var newEmployee = new Domain.Entities.Employee()
            {
                ParentId = request.ParentId,
                SubsidiaryId = request.SubsidiaryId,
                Names = request.Names,
                LastName = request.LastName,
                CatalogAreaId = request.CatalogAreaId,
                CatalogDepartmentId = request.CatalogDepartmentId,
                CatalogCostCenterId = request.CatalogCostCenterId,
                CatalogPositionId = request.CatalogPositionId,
                CatalogCurrencyId = request.CatalogCurrencyId,
                CatalogEmployeeTypeId = request.CatalogEmployeeTypeId,
                CostHour = request.CostHour,
                PhoneOffice = request.PhoneOffice,
                PhoneOfficeExt = request.PhoneOfficeExt,
                PhoneMobile = request.PhoneMobile,
                CalculateFactor = request.CalculateFactor,
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync(cancellationToken);

            var data = new List<string>() { newEmployee.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
