using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class ProjectReport : BaseEntity, IHasDomainEvent
    {
        public ProjectReport()
        {
            ProjectReportDetails = new HashSet<ProjectReportDetail>();
        }
        
        public Guid ProjectId { get; set; }
        public bool CustomerApproved { get; set; }
        public DateTime? CustomerApprovedDate { get; set; }
        public bool Invoiced { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }

        
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime? RealInvoiceDate { get; set; }
        public string? InvoiceComment { get; set; }

        public char State { get; set; }

        public DateTime ProjectReportDate { get; set; }

        public virtual Project Project { get; set; } 
        public virtual ICollection<ProjectReportDetail> ProjectReportDetails { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
