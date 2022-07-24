using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kameyo.Core.Application.Common.Mappings;
using System.Net;
using DevExtreme.AspNet.Data;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Project.Queries
{
    public class GetProjectsReportLoadOptionsQueryHandler : IRequestHandler<GetProjectsReportLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectsReportLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetProjectsReportLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var subsidiaries = _dbContext.ProjectReport
                .Include(x => x.Project)
                .Where(x => x.Active && x.Project.CustomerId == request.CustomerId)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(subsidiaries, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.ProjectReport>)loadResultResponse.data).MapToProjectReportsDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
