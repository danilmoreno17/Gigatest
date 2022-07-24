using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectTask.Commands
{
    public class DeleteProjectTaskCommandHandler : IRequestHandler<DeleteProjectTaskCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteProjectTaskCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteProjectTaskCommandRequest request, CancellationToken cancellationToken)
        {
            var projectTask = _dbContext.ProjectTasks.Where(b => b.Id == request.Id)
                     .FirstOrDefault();

            /*var validationResult = new DeleteSubsidiaryCommandValidator(subsidiary != null)
               .Validate(request);


            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            projectTask.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { projectTask.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
