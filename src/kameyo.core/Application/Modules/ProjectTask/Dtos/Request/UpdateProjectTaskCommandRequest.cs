using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request
{
    public class UpdateProjectTaskCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? ProjectId { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public Guid? CatalogTaskTypeId { get; set; } = default!;
        public int? Order { get; set; } = default!;
        public DateTime? StartDate { get; set; } = default!;
        public DateTime? EndDate { get; set; } = default!;
        public DateTime? CloseDate { get; set; } = default!;
        public int? DurationHour { get; set; } = default!;
        public int? Progress { get; set; } = default!;
        public Guid? CatalogTaskStateId { get; set; } = default!;
        public List<UpdateTaskActivityCommandRequest>? TaskActivities { get; set; } = default;
    }
}
