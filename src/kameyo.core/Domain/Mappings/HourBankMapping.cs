using Kameyo.Core.Application.Modules.HourBank.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class HourBankMapping
    {
        public HourBankMapping()
        { 
        }

        public static HourBanksDtoResponse MapToHourBanksDtoResponse(Kameyo.Core.Domain.Entities.HourBank entity) 
        {
            return new HourBanksDtoResponse
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                Name = entity.Name,
                Description = entity.Description,
                PurchaseOrderNumber = entity.PurchaseOrderNumber,
                InvoiceNumber = entity.InvoiceNumber,
                CatalogHourBankTypeId = entity.CatalogHourBankTypeId,
                ApplyValidity = entity.ApplyValidity,
                DateValidity = entity.DateValidity,
                Terms = entity.Terms,
                CatalogCurrencyId = entity.CatalogCurrencyId,
                HourCost = entity.HourCost,
                HourBalance = entity.HourBalance,
                HourSet = entity.HourSet,
            };
        }
        public static List<HourBanksDtoResponse> MapListToHourBanksDTO(ICollection<Domain.Entities.HourBank> hourBanksEntity)
        {
            var list = new List<HourBanksDtoResponse>();
            foreach (var entity in hourBanksEntity)
            {
                list.Add(MapToHourBanksDtoResponse(entity));
            }
            return list;
        }
    }
}
