using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Enums;
using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Person.Dtos.Request
{
    public class GetPersonLookUpLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }
    }
}
