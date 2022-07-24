using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request
{
    public class UpdateProjectHourBankCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid ProjectId { get; set; } = default!;
        public Guid HourBankId { get; set; } = default!;
    }
}
