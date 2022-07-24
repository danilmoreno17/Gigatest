using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReportDetail.Dtos.Response;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response
{
    public class ProjectReportDtoResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public bool CustomerApproved { get; set; }
        public DateTime? CustomerApprovedDate { get; set; }
        public bool Invoiced { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
        public char State{ get; set; }

        public DateTime ProjectReportDate { get; set; }
        public ProjectDtoResponse Project { get; set; }
        public string CustomerName { get; set; }

        public List<ProjectReportDetailDtoResponse> ProjectReportDetails { get; set; }

    }
}
