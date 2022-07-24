using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectResource.Commands
{
    public class UpdateProjectResourceCommandHandler : IRequestHandler<UpdateProjectResourceCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateProjectResourceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateProjectResourceCommandRequest request, CancellationToken cancellationToken)
        {
            var projectResource = _dbContext.ProjectResources.Where(b => b.Id == request.Id)
                    .FirstOrDefault();


            projectResource.ProjectId = request.ProjectId ?? projectResource.ProjectId;
            projectResource.EmployeeId = request.EmployeeId ?? projectResource.EmployeeId;
            projectResource.CatalogEmployeeRolId = request.CatalogEmployeeRolId ?? projectResource.CatalogEmployeeRolId;
            projectResource.CalculateFactorProject = request.CalculateFactorProject ?? projectResource.CalculateFactorProject;
            projectResource.CalculateFactorEmployee = request.CalculateFactorEmployee ?? projectResource.CalculateFactorEmployee;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { projectResource.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}