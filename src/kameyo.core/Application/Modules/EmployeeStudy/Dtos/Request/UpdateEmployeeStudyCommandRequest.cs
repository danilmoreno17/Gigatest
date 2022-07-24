using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request
{
    public class UpdateEmployeeStudyCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? Institution { get; set; }
        public string? Degree { get; set; }
        public string? FieldKnowledge { get; set; }
        public DateTime? EmissionDate { get; set; }
    }
}
