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
    public class CreateHourBankCommandHandler : IRequestHandler<CreateHourBankCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateHourBankCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateHourBankCommandRequest request, CancellationToken cancellationToken)
        {
            var hourBankExists = false;
            if (_dbContext.HourBanks.Count() > 0) 
            {
                hourBankExists = _dbContext.HourBanks.All(u => u.CustomerId == request.CustomerId && u.Name == request.Name && u.Active);
            }

            if (hourBankExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El nùmero ya existe",
                        Name=""
                    }
                });
            }

            var hourbank = new Domain.Entities.HourBank
            {
                CustomerId = request.CustomerId,
                Name = request.Name,
                Description = request.Description,
                PurchaseOrderNumber = request.PurchaseOrderNumber,
                InvoiceNumber = request.InvoiceNumber,
                CatalogHourBankTypeId = request.CatalogHourBankTypeId,
                ApplyValidity = request.ApplyValidity,
                DateValidity = request.DateValidity,
                Terms = request.Terms,
                CatalogCurrencyId = request.CatalogCurrencyId,
                HourCost = request.HourCost,
                HourBalance = request.HourBalance,
                HourSet = request.HourSet,
            };
            int createResult;
            _dbContext.HourBanks.Add(hourbank);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);
            var data = new List<string>
            {
                hourbank.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
