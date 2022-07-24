﻿using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request
{
    public class UpdateTaskActivityCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public Guid? ProjectTaskId { get; set; }
        public bool? IsBillable{ get; set; }
        public bool? InProjectReport { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalTimeHour { get; set; }

        public decimal? TotalTimeHourApproved { get; set; }
    }
}
