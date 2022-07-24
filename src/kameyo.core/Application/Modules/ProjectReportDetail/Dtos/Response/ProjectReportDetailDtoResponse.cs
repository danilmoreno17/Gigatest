using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReportDetail.Dtos.Response
{
    public class ProjectReportDetailDtoResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectReportId { get; set; }

        public Guid TaskActivityId { get; set; }


        public TaskActivitiesDtoResponse TaskActivity { get; set; }

        public ProjectReportDtoResponse ProjectReport { get; set; }

    }
}
