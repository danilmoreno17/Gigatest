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
    public class UpdateProjectHourBankCommandHandler : IRequestHandler<UpdateProjectHourBankCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateProjectHourBankCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateProjectHourBankCommandRequest request, CancellationToken cancellationToken)
        {
            var projectHourBank = _dbContext.ProjectHourBanks.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            projectHourBank.ProjectId = request.ProjectId;
            projectHourBank.HourBankId = request.HourBankId;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { projectHourBank.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
