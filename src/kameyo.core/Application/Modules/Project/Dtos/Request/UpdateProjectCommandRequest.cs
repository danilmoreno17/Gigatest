using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using MediatR;

namespace Kameyo.Core.Application.Modules.Project.Dtos.Request
{
    public class UpdateProjectCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CatalogProjectTypeId { get; set; }
        public Guid? CatalogProjectCategoryId { get; set; }
        public Guid? CatalogProjectStateId { get; set; }
        public Guid? MainContactId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DurationHour { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal CostHourMenCustomer { get; set; }
        public decimal CostHourMenProject { get; set; }
        public List<UpdateProjectTaskCommandRequest>? ProjectTasks { get; set; }
        public List<UpdateProjectResourceCommandRequest>? ProjectResources { get; set; }
        public List<UpdateProjectHourBankCommandRequest>? ProjectHourBanks { get; set; }
        public List<UpdateProjectManagerCommandRequest>? ProjectManagers { get; set; }

    }
}
