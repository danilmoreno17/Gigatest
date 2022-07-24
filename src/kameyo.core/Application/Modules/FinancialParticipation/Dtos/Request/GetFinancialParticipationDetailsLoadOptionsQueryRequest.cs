using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request
{
    public class GetFinancialParticipationDetailsLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }

        public int Year { get; set; }
        public Guid EmployeeId { get; set; }
        public int Month{ get; set; }
    }
}
