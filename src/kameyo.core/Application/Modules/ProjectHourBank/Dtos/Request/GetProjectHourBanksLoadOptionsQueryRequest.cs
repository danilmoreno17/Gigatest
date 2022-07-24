using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request
{
    public class GetProjectHourBanksLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }
    }
}
