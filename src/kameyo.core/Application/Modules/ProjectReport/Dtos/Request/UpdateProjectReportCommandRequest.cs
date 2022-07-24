using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request
{
    public class UpdateProjectReportCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public char? State{ get; set; }
        public string? InvoiceComment { get; set; }
        public DateTime? RealInvoiceDate { get; set; }
    }
}
