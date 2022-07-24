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
    public class CreateProjectHourBankCommandHandler : IRequestHandler<CreateProjectHourBankCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateProjectHourBankCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateProjectHourBankCommandRequest request, CancellationToken cancellationToken)
        {

            var deleteLastprojectHourBank = _dbContext.ProjectHourBanks.Where(X => X.ProjectId == request.ProjectId && X.Active).FirstOrDefault();

            if (deleteLastprojectHourBank != null) 
            {
                deleteLastprojectHourBank.Active = false;
            }


            var projectHourBankExists = false;
            if (_dbContext.ProjectHourBanks.Count() > 0)
            {
                projectHourBankExists = _dbContext.ProjectHourBanks.All(u => u.ProjectId == request.ProjectId && u.HourBankId == request.HourBankId && u.Active);
            }

            if (projectHourBankExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El asignacion ya existe",
                        Name=""
                    }
                });
            }

            var projectHourBank = new Domain.Entities.ProjectHourBank
            {
                ProjectId = request.ProjectId,
                HourBankId = request.HourBankId,
            };

            int createResult;
            _dbContext.ProjectHourBanks.Add(projectHourBank);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);


            var data = new List<string>
            {
                projectHourBank.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
