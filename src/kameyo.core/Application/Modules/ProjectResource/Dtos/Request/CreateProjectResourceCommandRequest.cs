using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request
{
    public class CreateProjectResourceCommandRequest : IRequest<Result<string>>
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? CatalogEmployeeRolId { get; set; }
        public decimal CalculateFactorEmployee { get; set; }
        public decimal CalculateFactorProject { get; set; }
    }
}
