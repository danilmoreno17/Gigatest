using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request
{
    public class UpdateProjectResourceCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? ProjectId { get; set; } = default!;
        public Guid? EmployeeId { get; set; } = default!;
        public Guid? CatalogEmployeeRolId { get; set; } = default!;
        public decimal? CalculateFactorEmployee { get; set; } = default!;
        public decimal? CalculateFactorProject { get; set; } = default!;
    }
}
