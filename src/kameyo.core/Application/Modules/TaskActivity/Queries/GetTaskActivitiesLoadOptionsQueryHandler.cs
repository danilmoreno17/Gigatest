using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.TaskActivity.Queries
{
    public class GetTaskActivitiesLoadOptionsQueryHandler : IRequestHandler<GetTaskActivitiesLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetTaskActivitiesLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoadResultModel> Handle(GetTaskActivitiesLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var taskActivity = _dbContext.TaskActivities
                .Where(x => x.Active && x.ProjectTaskId == (request.ProjectTaskId == null ? x.ProjectTaskId : request.ProjectTaskId.Value))
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(taskActivity, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.TaskActivity>)loadResultResponse.data).MapToTaskActivitiesDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
