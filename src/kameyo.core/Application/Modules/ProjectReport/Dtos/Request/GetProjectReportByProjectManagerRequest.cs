using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request
{
    public class GetProjectReportByProjectManagerRequest : IRequest<Result<ProjectReportDtoResponse>>
    {

        //public string Period { get; set; } = string.Empty; //202205
        public int? Year { get; set; }
        public int? Month { get; set; }
        public Guid? EmployeeId { get; set; }

    }
}
