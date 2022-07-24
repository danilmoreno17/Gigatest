using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Dtos.Request
{
    public class UpdateHourBankCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? CustomerId { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? PurchaseOrderNumber { get; set; } = default!;
        public string? InvoiceNumber { get; set; } = default!;
        public Guid? CatalogHourBankTypeId { get; set; } = default!;
        public bool? ApplyValidity { get; set; } = default!;
        public DateTime? DateValidity { get; set; } = default!;
        public string? Terms { get; set; } = default!;
        public Guid? CatalogCurrencyId { get; set; } = default!;
        public decimal? HourCost { get; set; } = default!;
        public int? HourBalance { get; set; } = default!;
        public int? HourSet { get; set; } = default!;
    }
}
