using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Commands
{
    public class DeleteTaskActivityCommandHandler : IRequestHandler<DeleteTaskActivityCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteTaskActivityCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteTaskActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var taskActivity = _dbContext.TaskActivities.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            /*var validationResult = new DeleteSubsidiaryCommandValidator(subsidiary != null)
               .Validate(request);


            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            taskActivity.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { taskActivity.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
