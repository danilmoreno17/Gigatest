using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectResource.Queries
{
    public class GetProjectResourcesLoadOptionsQueryHandler : IRequestHandler<GetProjectResourcesLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectResourcesLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetProjectResourcesLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var projectResource = _dbContext.ProjectResources
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(projectResource, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.ProjectResource>)loadResultResponse.data).MapToProjectResourcesDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK); throw new NotImplementedException();
        }
    }
}
