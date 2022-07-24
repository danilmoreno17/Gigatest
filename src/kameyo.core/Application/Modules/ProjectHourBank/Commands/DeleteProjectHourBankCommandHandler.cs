using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Commands
{
    public class DeleteProjectHourBankCommandHandler : IRequestHandler<DeleteProjectHourBankCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteProjectHourBankCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteProjectHourBankCommandRequest request, CancellationToken cancellationToken)
        {
            var projectHourBank = _dbContext.ProjectHourBanks.Where(b => b.Id == request.Id)
                     .FirstOrDefault();

            /*var validationResult = new DeleteSubsidiaryCommandValidator(subsidiary != null)
               .Validate(request);


            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            projectHourBank.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { projectHourBank.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
