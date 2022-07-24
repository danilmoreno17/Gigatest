using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Response
{
    public class EmployeeStudiesDtoResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string? FieldKnowledge { get; set; }
        public DateTime? EmissionDate { get; set; }
    }
}
