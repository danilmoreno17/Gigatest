using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Customer.Commands.Validators;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Customer.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id && x.Active, cancellationToken);

                var validationResult = await new UpdateCustomerCommandValidator()
                    .ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
                }

                customer.SubsidiaryId = request.SubsidiaryId ?? customer.SubsidiaryId;
                customer.CatalogTypeId = request.CatalogTypeId ?? customer.CatalogTypeId;
                customer.NumberId = request.NumberId ?? customer.NumberId;
                customer.Name = request.Name ?? customer.Name;
                customer.CatalogRegionCountryId = request.CatalogRegionCountryId ?? customer.CatalogRegionCountryId;
                customer.CatalogRegionStateId = request.CatalogRegionStateId ?? customer.CatalogRegionStateId;
                customer.CatalogRegionCityId = request.CatalogRegionCityId ?? customer.CatalogRegionCityId;
                customer.Address = request.Address ?? customer.Address;
                customer.Phone = request.Phone ?? customer.Phone;
                customer.CatalogIndustryTypeId = request.CatalogIndustryTypeId ?? customer.CatalogIndustryTypeId;
                customer.CatalogIndustrySubTypeId = request.CatalogIndustrySubTypeId ?? customer.CatalogIndustrySubTypeId;
                customer.CatalogCurrencyId = request.CatalogCurrencyId ?? customer.CatalogCurrencyId;
                customer.CostHourMen = request.CostHourMen;
                customer.Deadlinebilling = request.Deadlinebilling ?? customer.Deadlinebilling;


                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { customer.Id.ToString() }, HttpStatusCode.OK);

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
