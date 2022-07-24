using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Dtos.Request
{
    public class CreateHourBankCommandRequest : IRequest<Result<string>>
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public Guid? CatalogHourBankTypeId { get; set; }
        public bool? ApplyValidity { get; set; }
        public DateTime? DateValidity { get; set; }
        public string? Terms { get; set; }
        public Guid? CatalogCurrencyId { get; set; }
        public decimal HourCost { get; set; }
        public int HourBalance { get; set; }
        public int HourSet { get; set; }
    }
}
