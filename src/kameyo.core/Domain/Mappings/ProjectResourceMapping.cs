using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class ProjectResourceMapping
    {
        public ProjectResourceMapping()
        {
        }

        public static ProjectResourcesDtoResponse MapToProjectResourceDTO(Domain.Entities.ProjectResource entity)
        {
            return new ProjectResourcesDtoResponse
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                EmployeeId = entity.EmployeeId,
                EmployeName = entity.Employee.Names + ' ' + entity.Employee.LastName,
                ParticipationValue = entity.ParticipationValue,
                CatalogEmployeeRolId = entity.CatalogEmployeeRolId,
                CalculateFactorEmployee = entity.CalculateFactorEmployee,
                CalculateFactorProject = entity.CalculateFactorProject,
            };
        }

        public static List<ProjectResourcesDtoResponse> MapListToProjectResourcesDTO(ICollection<Domain.Entities.ProjectResource> projectResourcesEntity)
        {
            var list = new List<ProjectResourcesDtoResponse>();
            foreach (var entity in projectResourcesEntity)
            {
                list.Add(MapToProjectResourceDTO(entity));
            }
            return list;
        }
    }
}
