using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request
{
    public class GetProjectManagerQueryRequest : IRequest<Result<ProjectManagersDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
