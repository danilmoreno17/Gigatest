using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request
{
    public class CreateProjectReportRequest : IRequest<Result<string>>
    {
        //public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime ProjectReportDate { get; set; }
        public bool CustomerAproved { get; set; }
        public DateTime? AprovedDate { get; set; }
        public bool Invoiced { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public char? State { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }


    }
}
