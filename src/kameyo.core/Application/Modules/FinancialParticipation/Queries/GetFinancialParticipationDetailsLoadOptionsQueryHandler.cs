using Ardalis.Specification;
using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Kameyo.Core.Application.Modules.FinancialParticipation.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Queries
{
    public class GetFinancialParticipationDetailsLoadOptionsQueryHandler : IRequestHandler<GetFinancialParticipationDetailsLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _dbContext;
        
        public GetFinancialParticipationDetailsLoadOptionsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoadResultModel> Handle(GetFinancialParticipationDetailsLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            {
                request.LoadOptions ??= new DataSourceLoadOptionsBase();
                request.LoadOptions.PrimaryKey = new string[] { "Id" };

                var employees = _dbContext.ProjectReportDetail
                    .Include(x => x.TaskActivity)
                    .Include(x => x.ProjectReport)
                    .ThenInclude(x => x.Project)
                    .ThenInclude(x=> x.Customer)
                    .Where(x => x.Active && x.TaskActivity.EmployeeId == request.EmployeeId
                        && x.ProjectReport.Year == request.Year
                        && x.ProjectReport.Month == request.Month
                        && (x.ProjectReport.State == 'A' || x.ProjectReport.State == 'F' || x.ProjectReport.State == 'P')
                        )
                    .AsNoTracking();


                var loadResultResponse = await DataSourceLoader.LoadAsync(employees, request.LoadOptions, cancellationToken);
                loadResultResponse.data = ((IList<Domain.Entities.ProjectReportDetail>)loadResultResponse.data).MapToProjectReportsDetailDTO();

                return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
            }
  
    
        }
    }
}

