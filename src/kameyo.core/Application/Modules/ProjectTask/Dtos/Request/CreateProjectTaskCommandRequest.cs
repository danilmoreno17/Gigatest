using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request
{
    public class CreateProjectTaskCommandRequest : IRequest<Result<string>>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? CatalogTaskTypeId { get; set; }
        public int? Order { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? DurationHour { get; set; }
        public int? Progress { get; set; }
        public Guid? CatalogTaskStateId { get; set; }
    }
}
