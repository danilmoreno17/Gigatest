using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
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
    public class GetProjectsLoadOptionsQueryHandler : IRequestHandler<GetProjectsLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectsLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetProjectsLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var subsidiaries = _dbContext.Projects
                .Include(x => x.Customer)
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(subsidiaries, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.Project>)loadResultResponse.data).MapToProjectsDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
