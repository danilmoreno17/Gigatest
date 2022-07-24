using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectManager.Queries
{
    public class GetProjectManagersLoadOptionsQueryHandler : IRequestHandler<GetProjectManagersLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectManagersLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetProjectManagersLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var projectManager = _dbContext.ProjectManagers
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(projectManager, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.ProjectManager>)loadResultResponse.data).MapToProjectManagersDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK); throw new NotImplementedException();
        }
    }
}
