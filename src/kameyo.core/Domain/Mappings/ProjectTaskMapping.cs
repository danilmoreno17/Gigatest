using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;
using Kameyo.Core.Domain.Entities;

namespace Kameyo.Core.Domain.Mappings
{
    public class ProjectTaskMapping
    {
        public ProjectTaskMapping() { }

        public static ProjectTasksDtoResponse MapToProjectTasksDTO(Domain.Entities.ProjectTask entity)
        {
            return new ProjectTasksDtoResponse
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                ProjectName = entity.Project?.Name,
                Name = entity.Name,
                Description = entity.Description,
                CatalogTaskTypeId = entity.CatalogTaskTypeId,
                Order = entity.Order,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CloseDate = entity.CloseDate,
                DurationHour = entity.DurationHour,
                Progress = entity.Progress,
                CatalogTaskStateId = entity.CatalogTaskStateId,
                TaskActivities = entity.TaskActivities != null?TaskActivityMapping.MapListToTaskActivitiesDTO(entity.TaskActivities): new List<Application.Modules.TaskActivity.Dtos.Response.TaskActivitiesDtoResponse>(),
            };
        }

        public static List<ProjectTasksDtoResponse> MapListToProjectTasksDTO(ICollection<Domain.Entities.ProjectTask> projectTasksEntity)
        {
            var list = new List<ProjectTasksDtoResponse>();
            foreach (var entity in projectTasksEntity)
            {
                list.Add(MapToProjectTasksDTO(entity));
            }
            return list;
        }
    }
}
