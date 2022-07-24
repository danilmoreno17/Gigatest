using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response
{
    public  class ProjectReportGeneratorResponse
    {
        public Guid TaskActivityId { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
    }
}
