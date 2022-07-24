using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectManager.Commands
{
    public class UpdateProjectManagerCommandHandler : IRequestHandler<UpdateProjectManagerCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateProjectManagerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateProjectManagerCommandRequest request, CancellationToken cancellationToken)
        {
            var projectManager = _dbContext.ProjectManagers.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            projectManager.ProjectId = request.ProjectId??projectManager.ProjectId;
            projectManager.EmployeeId = request.EmployeeId ?? projectManager.EmployeeId;
            projectManager.StartDate = request.StartDate ?? projectManager.StartDate;
            projectManager.EndDate = request.EndDate ?? projectManager.EndDate;
            

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { projectManager.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
