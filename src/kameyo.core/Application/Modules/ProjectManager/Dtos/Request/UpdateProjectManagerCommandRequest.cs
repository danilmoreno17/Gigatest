using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request
{
    public class UpdateProjectManagerCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? ProjectId { get; set; } = default!;
        public Guid? EmployeeId { get; set; } = default!;
        public DateTime? StartDate { get; set; } = default!;
        public DateTime? EndDate { get; set; } = default!;
    }
}
