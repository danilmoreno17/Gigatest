using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Domain.Entities
{
    public partial class TaskActivity : BaseEntity, IHasDomainEvent
    {
        public TaskActivity()
        {
            //ProjectReportDetails = new HashSet<ProjectReportDetail>();
        }

        public Guid ProjectTaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalTimeHour { get; set; }
        public decimal TotalTimeHourApproved { get; set; }
        public bool IsBillable { get; set; }
        public bool InProjectReport { get; set; }
        public DateTime? InProjectReportDate { get; set; }
        public bool Invoiced { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }

        public decimal? CalculateFactor { get; set; }
        public decimal? HourCost { get; set; }
        public decimal? TotalCost { get; set; }
        public Guid? CommissionId{ get; set; }
        public Guid? ExchangeRate { get; set; }

        public virtual ProjectTask? ProjectTask { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ProjectReportDetail ProjectReportDetails { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
