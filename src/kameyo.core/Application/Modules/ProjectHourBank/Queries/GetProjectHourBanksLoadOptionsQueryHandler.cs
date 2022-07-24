using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Queries
{
    public class GetProjectHourBanksLoadOptionsQueryHandler : IRequestHandler<GetProjectHourBanksLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectHourBanksLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetProjectHourBanksLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var projectHourBank = _dbContext.ProjectHourBanks
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(projectHourBank, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.ProjectHourBank>)loadResultResponse.data).MapToProjectHourBanksDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK); throw new NotImplementedException();
        }
    }
}
