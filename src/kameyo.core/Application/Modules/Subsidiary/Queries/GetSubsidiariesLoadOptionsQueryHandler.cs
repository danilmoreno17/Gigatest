using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Kameyo.Core.Application.Common.Mappings;

namespace Kameyo.Core.Application.Modules.Subsidiary.Queries
{
    public class GetSubsidiariesLoadOptionsQueryHandler : IRequestHandler<GetSubsidiariesLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetSubsidiariesLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetSubsidiariesLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var subsidiaries = _dbContext.Subsidiaries
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(subsidiaries, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.Subsidiary>)loadResultResponse.data).MapToSubsidiariesDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
