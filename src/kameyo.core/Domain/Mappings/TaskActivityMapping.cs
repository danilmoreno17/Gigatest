using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;

namespace Kameyo.Core.Domain.Mappings
{
    public class TaskActivityMapping
    {
        public TaskActivityMapping() { }

        public static TaskActivitiesDtoResponse MapToTaskActivitiesDTO(Domain.Entities.TaskActivity entity) 
        {
            return new TaskActivitiesDtoResponse
            {
                Id = entity.Id,
                ProjectTaskId = entity.ProjectTaskId,
                EmployeeId = entity.EmployeeId,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                TotalTimeHour = entity.TotalTimeHour,
                TotalCost = entity.TotalCost,
                TotalTimeHourApproved = entity.TotalTimeHourApproved,
                IsBillable = entity.IsBillable,
                InProjectReport = entity.InProjectReport
            };
        }

        public static List<TaskActivitiesDtoResponse> MapListToTaskActivitiesDTO(ICollection<Domain.Entities.TaskActivity> taskActivitiesEntity)
        {
            var list = new List<TaskActivitiesDtoResponse>();
            foreach (var entity in taskActivitiesEntity)
            {
                list.Add(MapToTaskActivitiesDTO(entity));
            }
            return list;
        }
    }
}
