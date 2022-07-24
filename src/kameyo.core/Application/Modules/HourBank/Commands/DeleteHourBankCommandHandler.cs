using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Commands
{
    public class DeleteHourBankCommandHandler : IRequestHandler<DeleteHourBankCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteHourBankCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteHourBankCommandRequest request, CancellationToken cancellationToken)
        {
            var hourBank = _dbContext.HourBanks.Where(b => b.Id == request.Id)
                     .FirstOrDefault();
            hourBank.Active = false;
            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);
            return Result<string>.Success(new List<string> { hourBank.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
