using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Commands.Validators;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.Company.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {

            var companyExits = _context.Companies.All(z => z.NumberId == request.NumberId && z.Active);
            if (companyExits)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="La empresa ya existe",
                        Name=""
                    }
                });
            }

            /*var validationResult = await new CreateCompanyCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/


            var newCompany = new Domain.Entities.Company()
            {
                CatalogTypeId = request.CatalogTypeId,
                NumberId = request.NumberId,
                Name = request.Name,
                CatalogRegionCountryId = request.CatalogRegionCountryId,
                CatalogRegionStateId = request.CatalogRegionStateId,
                CatalogRegionCityId = request.CatalogRegionCityId,
                Address = request.Address
            };


            _context.Companies.Add(newCompany);
            await _context.SaveChangesAsync(cancellationToken);

            var data = new List<string>() { newCompany.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);


        }
    }
}
