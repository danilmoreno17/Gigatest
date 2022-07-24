using Kameyo.Core.Application.Modules.Customer.Mapping;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Domain.Mappings;

namespace Kameyo.Core.Application.Modules.Project.Mapping
{
    public class ProjectMapping
    {
        public ProjectMapping()
        {

        }

        public static ProjectDtoResponse MapToProjectDTO(Domain.Entities.Project entity)
        {
            return new ProjectDtoResponse
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                SubsidiaryId = entity.Customer?.SubsidiaryId,
                Name = entity.Name,
                Description = entity.Description,
                CatalogProjectCategoryId = entity.CatalogProjectCategoryId,
                CatalogProjectStateId = entity.CatalogProjectStateId,
                CatalogProjectTypeId = entity.CatalogProjectTypeId,
                MainContactId = entity.MainContactId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                DurationHour = entity.DurationHour,
                CloseDate = entity.CloseDate,
                CostHourMenCustomer = entity.CostHourMenCustomer,
                CostHourMenProject = entity.CostHourMenProject,
                ProjectTasks = entity.ProjectTasks != null ? ProjectTaskMapping.MapListToProjectTasksDTO(entity.ProjectTasks) : new List<ProjectTask.Dtos.Response.ProjectTasksDtoResponse>(),
                ProjectResources = entity.ProjectResources != null ? ProjectResourceMapping.MapListToProjectResourcesDTO(entity.ProjectResources) : new List<ProjectResource.Dtos.Response.ProjectResourcesDtoResponse>(),
                ProjectHourBanks = entity.ProjectHourBanks != null ? ProjectHourBankMapping.MapListToProjectHourBanksDTO(entity.ProjectHourBanks) : new List<ProjectHourBank.Dtos.Response.ProjectHourBanksDtoResponse>(),
                ProjectManagers = entity.ProjectManagers != null ? ProjectManagerMapping.MapListToProjectManagersDTO(entity.ProjectManagers) : new List<ProjectManager.Dtos.Response.ProjectManagersDtoResponse>(),
            };
        }

        public static List<ProjectDtoResponse> MapListToProjectsDTO(ICollection<Domain.Entities.Project> projectTasksEntity) 
        {
            var list = new List<ProjectDtoResponse>();
            foreach (var entity in projectTasksEntity)
            {
                list.Add(MapToProjectDTO(entity));
            }
            return list;
        }
    }
}
