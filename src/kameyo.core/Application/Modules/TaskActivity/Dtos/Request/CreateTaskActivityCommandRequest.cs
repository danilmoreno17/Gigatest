using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request
{
    public class CreateTaskActivityCommandRequest : IRequest<Result<string>>
    {
        public Guid ProjectTaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }

        public bool IsBillable { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalTimeHour { get; set; }
        public decimal TotalTimeHourApproved { get; set; }
    }
}
