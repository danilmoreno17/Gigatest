using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;

namespace Kameyo.Core.Application.Modules.Project.Dtos.Response
{
    public class ProjectDtoResponse
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SubsidiaryId { get; set; }
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

        public List<ProjectTasksDtoResponse> ProjectTasks { get; set; }
        public List<ProjectResourcesDtoResponse> ProjectResources { get; set; }
        public List<ProjectHourBanksDtoResponse> ProjectHourBanks { get; set; }
        public List<ProjectManagersDtoResponse> ProjectManagers { get; set; }

    }
}
