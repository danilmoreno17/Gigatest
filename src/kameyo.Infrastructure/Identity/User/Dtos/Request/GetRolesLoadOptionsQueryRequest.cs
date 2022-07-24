using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class GetRolesLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }
    }
}
