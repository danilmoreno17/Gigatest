using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Person.Dtos.Request;
using Kameyo.Core.Application.Modules.Person.Model;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.Person.Queries
{
    public class GetPersonTypeLoadOptionsQueryHandler : IRequestHandler<GetPersonTypeLoadOptionsQueryRequest, LoadResultModel>
    {
        public GetPersonTypeLoadOptionsQueryHandler()
        {

        }
        public async Task<LoadResultModel> Handle(GetPersonTypeLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            var loadResultResponse = DataSourceLoader.Load(PersonTypeModel.LoadPersonTypes(), request.LoadOptions);
            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
