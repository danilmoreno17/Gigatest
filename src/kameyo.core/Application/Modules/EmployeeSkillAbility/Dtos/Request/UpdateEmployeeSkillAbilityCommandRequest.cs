using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request
{
    public class UpdateEmployeeSkillAbilityCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? Description { get; set; }
    }
}
