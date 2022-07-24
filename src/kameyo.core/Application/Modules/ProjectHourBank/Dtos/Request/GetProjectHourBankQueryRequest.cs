using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request
{
    public class GetProjectHourBankQueryRequest : IRequest<Result<ProjectHourBanksDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
