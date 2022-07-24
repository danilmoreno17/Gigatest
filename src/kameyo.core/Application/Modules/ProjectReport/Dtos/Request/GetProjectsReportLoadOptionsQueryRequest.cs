using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request
{
    public class GetProjectsReportLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }
        public Guid CustomerId { get; set; }
        public int Year{ get; set; }
        public int Month { get; set; }
    }
}
