using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request
{
    public class CreateEmployeeSkillAbilityCommandRequest : IRequest<Result<string>>
    {
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
    }
}
