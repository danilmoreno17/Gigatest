using Kameyo.Core.Application.Common.Models;

using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request
{
    public class GetProjectReportQueryRequest : IRequest<Result<ProjectReportDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
