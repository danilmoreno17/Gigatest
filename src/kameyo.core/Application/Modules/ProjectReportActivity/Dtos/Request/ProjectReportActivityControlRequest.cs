using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Request
{
    public class ProjectReportActivityControlRequest : IRequest<Result<ProjectReportActivityControlResponse>>
    {
        public Guid ProjectId { get;set; }
    }
}
