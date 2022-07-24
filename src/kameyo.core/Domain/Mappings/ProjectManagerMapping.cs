using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class ProjectManagerMapping
    {
        public ProjectManagerMapping()
        {
        }

        public static ProjectManagersDtoResponse MapToProjectManagerDTO(Domain.Entities.ProjectManager entity)
        {
            return new ProjectManagersDtoResponse
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                EmployeeId = entity.EmployeeId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };
        }

        public static List<ProjectManagersDtoResponse> MapListToProjectManagersDTO(ICollection<Domain.Entities.ProjectManager> projectManagersEntity)
        {
            var list = new List<ProjectManagersDtoResponse>();
            foreach (var entity in projectManagersEntity)
            {
                list.Add(MapToProjectManagerDTO(entity));
            }
            return list;
        }
    }
}
