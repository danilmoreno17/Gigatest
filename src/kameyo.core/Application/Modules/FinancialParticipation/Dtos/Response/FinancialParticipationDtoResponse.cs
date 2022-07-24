using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response
{
    public class FinancialParticipationDtoResponse
    {
        public FinancialParticipationDtoResponse() {
            this.Description = String.Empty;
        }
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public char Status { get; set; }
        public char Type { get; set; }
        public Guid? CatalogDiscretionaryTypeId { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public EmployeeDtoResponse Employee { get; set; }
    }
}
