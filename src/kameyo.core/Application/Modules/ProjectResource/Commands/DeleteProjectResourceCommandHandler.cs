using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectResource.Commands
{
    public class DeleteProjectResourceCommandHandler : IRequestHandler<DeleteProjectResourceCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteProjectResourceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteProjectResourceCommandRequest request, CancellationToken cancellationToken)
        {
            var projectResource = _dbContext.ProjectResources.Where(b => b.Id == request.Id)
                     .FirstOrDefault();

            /*var validationResult = new DeleteSubsidiaryCommandValidator(subsidiary != null)
               .Validate(request);


            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            projectResource.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { projectResource.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
