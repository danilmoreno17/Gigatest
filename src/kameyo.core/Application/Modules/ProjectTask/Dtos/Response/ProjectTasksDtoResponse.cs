using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response
{
    public class ProjectTasksDtoResponse
    {
        public Guid Id { get; set; }
        public Guid? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CatalogTaskTypeId { get; set; }
        public int? Order { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? DurationHour { get; set; }
        public int? Progress { get; set; }
        public Guid? CatalogTaskStateId { get; set; }
        public List<TaskActivitiesDtoResponse> TaskActivities { get; set; }
    }
}
