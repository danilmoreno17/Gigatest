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
    public class UpdateHourBankCommandHandler : IRequestHandler<UpdateHourBankCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateHourBankCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateHourBankCommandRequest request, CancellationToken cancellationToken)
        {
            var hourBank = _dbContext.HourBanks.Where(b => b.Id == request.Id)
                    .FirstOrDefault();
            hourBank.CustomerId = request.CustomerId?? hourBank.CustomerId;
            hourBank.Name = request.Name??hourBank.Name;
            hourBank.Description = request.Description ?? hourBank.Description;
            hourBank.PurchaseOrderNumber = request.PurchaseOrderNumber ?? hourBank.PurchaseOrderNumber;
            hourBank.InvoiceNumber = request.InvoiceNumber ?? hourBank.InvoiceNumber;
            hourBank.CatalogHourBankTypeId = request.CatalogHourBankTypeId ?? hourBank.CatalogHourBankTypeId;
            hourBank.ApplyValidity = request.ApplyValidity ?? hourBank.ApplyValidity;
            hourBank.Terms = request.Terms ?? hourBank.Terms;
            hourBank.CatalogCurrencyId  = request.CatalogCurrencyId ?? hourBank.CatalogCurrencyId;
            hourBank.HourCost = request.HourCost ?? hourBank.HourCost;
            hourBank.HourBalance = request.HourBalance ?? hourBank.HourBalance;
            hourBank.HourSet = request.HourSet ?? hourBank.HourSet;

            int uodateResult = await _dbContext.SaveChangesAsync(cancellationToken);
            return Result<string>.Success(new List<string> { hourBank.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
