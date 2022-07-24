using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request
{
    public class FinancialParticipationGeneralRequest : IRequest<Result<FinancialParticipationDtoResponse>>
    {

        //public string Period { get; set; } = string.Empty; //202205
        public Guid? EmployeeId { get; set; }
        public int Year { get; set; }
        public char Type { get; set; }
        public int Month { get; set; }

    }
}
