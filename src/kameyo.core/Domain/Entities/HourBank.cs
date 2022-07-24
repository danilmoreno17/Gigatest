using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class HourBank : BaseEntity, IHasDomainEvent
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

        public virtual Customer Customer { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
