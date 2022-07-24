using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Project.Dtos.Request
{
    public class GetProjectQueryRequest : IRequest<Result<ProjectDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
