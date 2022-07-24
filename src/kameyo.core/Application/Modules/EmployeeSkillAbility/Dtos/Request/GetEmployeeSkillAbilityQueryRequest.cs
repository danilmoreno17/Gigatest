using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request
{
    public class GetEmployeeSkillAbilityQueryRequest : IRequest<Result<EmployeeSkillAbilitiesDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
