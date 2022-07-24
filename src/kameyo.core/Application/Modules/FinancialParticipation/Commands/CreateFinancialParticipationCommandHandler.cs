using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Commands
{
    public class CreateFinancialParticipationCommandHandler : IRequestHandler<CreateFinancialParticipationCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateFinancialParticipationCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateFinancialParticipationCommandRequest request, CancellationToken cancellationToken)
        {

            var financialParticipation = new Domain.Entities.FinancialParticipation
            {
                EmployeeId = request.EmployeeId,
                Description = request.Description,
                CatalogDiscretionaryTypeId = request.CatalogDiscretionaryTypeId,
                Status = request.Status,
                Month = request.Month,
                Year = request.Year,
                Type = request.Type,
                Value = request.Value
            };

            //creación de comisión indirecta


            int createResult;
            _dbContext.FinancialParticipation.Add(financialParticipation);

            var employee = await _dbContext.Employees.FindAsync(request.EmployeeId);

            if (employee != null && employee.ParentId != null)
            {

                var financialParticipationIndirect = new Domain.Entities.FinancialParticipation
                {
                    EmployeeId = employee.ParentId.Value,
                    Description = String.Format("Participación Indirecta ({0} {1})", employee.LastName, employee.Names),
                    CatalogDiscretionaryTypeId = null,
                    Status = request.Status,
                    Month = request.Month,
                    Year = request.Year,
                    Type = 'I',
                    Value = request.Value * 0.05m
                };

                _dbContext.FinancialParticipation.Add(financialParticipationIndirect);
            }

            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            /*if (createResult<=0)
            {
                return Result<string>.PreconditionFailure(.Errors.MapToResultValidationFailure());
            }*/

            var data = new List<string>
            {
                financialParticipation.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
