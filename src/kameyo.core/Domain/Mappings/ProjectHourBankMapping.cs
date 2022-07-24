using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class ProjectHourBankMapping
    {
        public ProjectHourBankMapping()
        {
        }

        public static ProjectHourBanksDtoResponse MapToProjectHourBankDTO(Domain.Entities.ProjectHourBank entity)
        {
            return new ProjectHourBanksDtoResponse
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                HourBankId = entity.HourBankId,
                HourBalance = entity.HourBank?.HourBalance,
                HourSet = entity.HourBank?.HourSet,
            };
        }

        public static List<ProjectHourBanksDtoResponse> MapListToProjectHourBanksDTO(ICollection<Domain.Entities.ProjectHourBank> projectHourBanksEntity)
        {
            var list = new List<ProjectHourBanksDtoResponse>();
            foreach (var entity in projectHourBanksEntity)
            {
                list.Add(MapToProjectHourBankDTO(entity));
            }
            return list;
        }
    }
}
