using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Request
{
    public class GetEmployeeExperienceQueryRequest : IRequest<Result<EmployeeExperiencesDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
