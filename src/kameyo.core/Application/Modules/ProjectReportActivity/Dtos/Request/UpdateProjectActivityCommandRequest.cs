using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Request
{
    public class UpdateProjectActivityCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public string? Observation { get; set; }

        public bool? IsBillable { get; set; }

        public int? TotalTimeHourApproved { get; set; }
        public Guid TaskActivityId { get; set; }
    }
}
