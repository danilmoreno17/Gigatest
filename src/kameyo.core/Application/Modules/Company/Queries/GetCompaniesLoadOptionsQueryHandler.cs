using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Company.Queries
{
    public class GetCompaniesLoadOptionsQueryHandler : IRequestHandler<GetCompaniesLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetCompaniesLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoadResultModel> Handle(GetCompaniesLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            request.LoadOptions ??= new DataSourceLoadOptionsBase();
            request.LoadOptions.PrimaryKey = new string[] { "Id" };

            var companies = _dbContext.Companies
                .Where(x => x.Active)
                .AsNoTracking();


            var loadResultResponse = await DataSourceLoader.LoadAsync(companies, request.LoadOptions, cancellationToken);
            loadResultResponse.data = ((IList<Domain.Entities.Company>)loadResultResponse.data).MapToCompaniesDTO();

            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }
    }
}
