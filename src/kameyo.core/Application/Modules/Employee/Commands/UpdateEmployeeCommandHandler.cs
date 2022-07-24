using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Commands.Validators;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Employee.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = _context.Employees.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

                /*var validationResult = await new UpdateEmployeeCommandValidator()
                    .ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
                }*/

                employee.ParentId = request.ParentId ?? employee.ParentId;
                employee.SubsidiaryId = request.SubsidiaryId ?? employee.SubsidiaryId;
                employee.Names = request.Names ?? employee.Names;
                employee.LastName = request.LastName ?? employee.LastName;
                employee.CatalogAreaId = request.CatalogAreaId ?? employee.CatalogAreaId;
                employee.CatalogDepartmentId = request.CatalogDepartmentId ?? employee.CatalogDepartmentId;
                employee.CatalogCostCenterId = request.CatalogCostCenterId ?? employee.CatalogCostCenterId;
                employee.CatalogPositionId = request.CatalogPositionId ?? employee.CatalogPositionId;
                employee.CatalogCurrencyId = request.CatalogCurrencyId ?? employee.CatalogCurrencyId;
                employee.CatalogEmployeeTypeId = request.CatalogEmployeeTypeId ?? employee.CatalogEmployeeTypeId;
                employee.CostHour = request.CostHour??employee.CostHour;
                employee.PhoneOffice = request.PhoneOffice ?? employee.PhoneOffice;
                employee.PhoneOfficeExt = request.PhoneOfficeExt ?? employee.PhoneOfficeExt;
                employee.PhoneMobile = request.PhoneMobile ?? employee.PhoneMobile;
                employee.CalculateFactor = request.CalculateFactor??employee.CalculateFactor;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { employee.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>()
                    {new () {Message = "Se genero una exception"}};
                return Result<string>.PreconditionFailure(errors);
            }
        }
    }
}