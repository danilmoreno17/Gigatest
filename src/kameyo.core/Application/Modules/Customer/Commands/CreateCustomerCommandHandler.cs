using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Customer.Commands.Validators;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.Customer.Commands
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {

            var customerExits = _context.Customers.All(z => z.NumberId == request.NumberId && z.Active);
            if (customerExits)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El cliente ya existe",
                        Name=""
                    }
                });
            }

            var validationResult = await new CreateCustomerCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }


            var newCustomer = new Domain.Entities.Customer()
            {
                SubsidiaryId = request.SubsidiaryId,
                CatalogTypeId = request.CatalogTypeId,
                NumberId = request.NumberId,
                Name = request.Name,
                CatalogRegionCountryId = request.CatalogRegionCountryId,
                CatalogRegionStateId = request.CatalogRegionStateId,
                CatalogRegionCityId = request.CatalogRegionCityId,
                Address = request.Address,
                Phone = request.Phone,
                CatalogIndustryTypeId = request.CatalogIndustryTypeId,
                CatalogIndustrySubTypeId = request.CatalogIndustrySubTypeId,
                CostHourMen = request.CostHourMen,
                Deadlinebilling = request.Deadlinebilling,
            };


            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync(cancellationToken);

            var data = new List<string>() { newCustomer.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);


        }
    }
}