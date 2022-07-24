using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response
{
    public class ProjectResourcesDtoResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeName { get; set; }
        public decimal ParticipationValue { get; set; }
        public Guid? CatalogEmployeeRolId { get; set; }
        public decimal CalculateFactorEmployee { get; set; }
        public decimal CalculateFactorProject { get; set; }
    }
}
