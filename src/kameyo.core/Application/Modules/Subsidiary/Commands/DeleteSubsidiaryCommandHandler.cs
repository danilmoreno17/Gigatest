using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Commands.Validators;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.Subsidiary.Commands
{
    public class DeleteSubsidiaryCommandHandler : IRequestHandler<DeleteSubsidiaryCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteSubsidiaryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteSubsidiaryCommandRequest request, CancellationToken cancellationToken)
        {
            var subsidiary = _dbContext.Subsidiaries.Where(b => b.Id == request.Id)
                     .FirstOrDefault();

            /*var validationResult = new DeleteSubsidiaryCommandValidator(subsidiary != null)
               .Validate(request);


            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            subsidiary.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { subsidiary.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
