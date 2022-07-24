using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Commands.Validators;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Kameyo.Core.Application.Modules.Subsidiary.Commands
{
    public class CreateSubsidiaryCommandHandler : IRequestHandler<CreateSubsidiaryCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateSubsidiaryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateSubsidiaryCommandRequest request, CancellationToken cancellationToken)
        {
            var subsidiaryExists = false;
            if (_dbContext.Subsidiaries.Count() > 0) 
            {
               subsidiaryExists = _dbContext.Subsidiaries.All(u => u.NumberId == request.NumberId && u.Active);

            }

            if (subsidiaryExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El nùmero ya existe",
                        Name=""
                    }
                });
            }


            //TODO Hacer funcionar el CreateSubsidiaryCommandValidator
            /*var validationResult = new CreateSubsidiaryCommandValidator(subsidiaryExists)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            var subsidiary = new Domain.Entities.Subsidiary
            {
                CompanyId = request.CompanyId,
                CatalogTypeId = request.CatalogTypeId,
                NumberId = request.NumberId,
                Name = request.Name,
                CatalogRegionCountryId = request.CatalogRegionCountryId,
                CatalogRegionStateId = request.CatalogRegionStateId,
                CatalogRegionCityId = request.CatalogRegionCityId,
                Address = request.Address,
                PctPartIndrctCommissions = request.pctPartIndrctCommissions,
            };

            int createResult;
            _dbContext.Subsidiaries.Add(subsidiary);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);


            /*if (createResult<=0)
            {
                return Result<string>.PreconditionFailure(.Errors.MapToResultValidationFailure());
            }*/

            var data = new List<string>
            {
                subsidiary.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
