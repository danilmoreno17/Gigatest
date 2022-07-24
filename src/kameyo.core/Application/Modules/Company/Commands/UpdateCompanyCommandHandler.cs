using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Commands.Validators;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Company.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.Id && x.Active, cancellationToken);

                /*var validationResult = await new UpdateCompanyCommandValidator()
                    .ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
                }*/
                
                if(request.CatalogTypeId!=null)
                    company.CatalogTypeId = request.CatalogTypeId;
                if (request.NumberId != null)
                    company.NumberId = request.NumberId;
                if (request.Name != null)
                    company.Name = request.Name;
                if (request.CatalogRegionCountryId != null)
                    company.CatalogRegionCountryId = request.CatalogRegionCountryId;
                if (request.CatalogRegionStateId != null) 
                    company.CatalogRegionStateId = request.CatalogRegionStateId;
                if (request.CatalogRegionCityId != null) 
                    company.CatalogRegionCityId = request.CatalogRegionCityId;
                if (request.Address != null) 
                    company.Address = request.Address;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { company.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception e)
            {
                var errors = new List<ResultValidationFailure>()
                    {new () {Message = "Se genero una exception"}};
                return Result<string>.PreconditionFailure(errors);
            }
        }
    }
}
