using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Commands.Validators;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Commands
{
    public class UpdateSubsidiaryCommandHandler : IRequestHandler<UpdateSubsidiaryCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateSubsidiaryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateSubsidiaryCommandRequest request, CancellationToken cancellationToken)
        {
            var subsidiary = _dbContext.Subsidiaries.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            /*var validationResult = new UpdateSubsidiaryCommandValidator(subsidiary!=null)
               .Validate(request);


            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/
            subsidiary.Name = request.Name ?? subsidiary.Name;
            subsidiary.CompanyId = request.CompanyId ?? subsidiary.CompanyId;
            subsidiary.NumberId = request.NumberId ?? subsidiary.NumberId ;
            subsidiary.CatalogRegionCountryId = request.CatalogRegionCountryId ?? subsidiary.CatalogRegionCountryId ;
            subsidiary.CatalogRegionStateId = request.CatalogRegionStateId ?? subsidiary.CatalogRegionStateId ;
            subsidiary.CatalogRegionCityId = request.CatalogRegionCityId ?? subsidiary.CatalogRegionCityId ;
            subsidiary.Address = request.Address ?? subsidiary.Address;
            subsidiary.PctPartIndrctCommissions = request.pctPartIndrctCommissions ?? subsidiary.PctPartIndrctCommissions ;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { subsidiary.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
