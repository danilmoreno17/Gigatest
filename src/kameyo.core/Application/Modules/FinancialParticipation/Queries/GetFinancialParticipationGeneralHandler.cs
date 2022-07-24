using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;

using Kameyo.Core.Application.Modules.ProjectReport.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Queries
{
    public class GetFinancialParticipationGeneralHandler : IRequestHandler<FinancialParticipationGeneralRequest, Result<FinancialParticipationDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        private readonly string FILTER_FIELD_NAME = "NAME";
        public GetFinancialParticipationGeneralHandler(IApplicationDbContext context)
        {
            this._context= context;
        }


        public async Task<Result<FinancialParticipationDtoResponse>> Handle(FinancialParticipationGeneralRequest request, CancellationToken cancellationToken)
        {

        
            if (request.Type == 'D')
            {
                //var specification = GetSpecification(request);
                var FinancialParticipation = await _context.FinancialParticipation
                    .Include(x => x.Employee)
                    .Where(x => x.Type == request.Type && x.EmployeeId == request.EmployeeId)
                    .Select(x => FinancialParticipationMapping.MapToFinancialParticipationDTO(x))
                    .ToListAsync();

                if (FinancialParticipation == null) return Result<FinancialParticipationDtoResponse>.NotFound();

                return Result<FinancialParticipationDtoResponse>.Success(FinancialParticipation); 
            }
            else {
                var FinancialParticipation = await _context.FinancialParticipation
                    .Where(x =>x.EmployeeId == request.EmployeeId)
                .Select(x => FinancialParticipationMapping.MapToFinancialParticipationDTO(x))

                 .ToListAsync(); 

                if (FinancialParticipation == null) return Result<FinancialParticipationDtoResponse>.NotFound();
                return Result<FinancialParticipationDtoResponse>.Success(FinancialParticipation);
            }

        }

        /*
        private ISpecification<Domain.Entities.FinancialParticipation> GetSpecification(FinancialParticipationGeneralRequest request)
        {
            ISpecification<Domain.Entities.ProjectReport> specification = new GetProjectReportByIdSepec(request.Value);

            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetProjectReportByIdSepec(request.Value);
            }
            return specification;
        }
        */
    }
}
