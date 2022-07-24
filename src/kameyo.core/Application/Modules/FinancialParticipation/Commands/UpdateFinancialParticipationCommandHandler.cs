using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
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
    public class UpdateFinancialParticipationCommandHandler : IRequestHandler<UpdateFinancialParticipationCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateFinancialParticipationCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateFinancialParticipationCommandRequest request, CancellationToken cancellationToken)
        {
            var financialParticipation = _dbContext.FinancialParticipation.Where(b => b.Id == request.Id)
                    .FirstOrDefault();   
            
            if (financialParticipation == null)
                return Result<string>.NotFound();
            if(request.Value!=null)
            financialParticipation.Value = request.Value.Value;
            if (request.Year != null)
                financialParticipation.Year = request.Year.Value;
            if (request.Month != null)
                financialParticipation.Month = request.Month.Value;
            if (request.Description != null)
                financialParticipation.Description = request.Description;
            if (request.Status != null)
                financialParticipation.Status = request.Status.Value;




            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);


            return Result<string>.Success(new List<string> { financialParticipation.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
