using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Response
{
    public class ProjectReportActivityControlResponse
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Value { get; set; }
        public bool? IsBillable { get; set; }
        public string? Consultant { get; set; }

        public decimal? Factor { get; set; }
        public decimal? TotaTimeHour { get; set; }
        public decimal? TotalTimeHourApproved { get; set; }
        public string? Observation { get; set; }
    }
}
