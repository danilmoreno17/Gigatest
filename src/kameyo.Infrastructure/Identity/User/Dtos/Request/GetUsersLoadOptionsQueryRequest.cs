using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class GetUsersLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }
    }
}
