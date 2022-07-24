using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request
{
    public class CreateFinancialParticipationCommandRequest : IRequest<Result<string>>
    {
        public Guid EmployeeId { get; set; }

        public char Type { get; set; }
        public Guid? CatalogDiscretionaryTypeId { get; set; }
        public decimal Value { get; set; }
        public char Status { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
