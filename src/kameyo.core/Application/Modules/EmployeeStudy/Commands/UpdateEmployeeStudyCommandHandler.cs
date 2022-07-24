using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Commands
{
    public class UpdateEmployeeStudyCommandHandler : IRequestHandler<UpdateEmployeeStudyCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateEmployeeStudyCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateEmployeeStudyCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeStudy = _dbContext.EmployeeStudies.Where(b => b.Id == request.Id)
                    .FirstOrDefault();


            employeeStudy.EmployeeId = request.EmployeeId ?? employeeStudy.EmployeeId;
            employeeStudy.Institution = request.Institution ?? employeeStudy.Institution;
            employeeStudy.Degree = request.Degree ?? employeeStudy.Degree;
            employeeStudy.FieldKnowledge = request.FieldKnowledge ?? employeeStudy.FieldKnowledge;
            employeeStudy.EmissionDate = request.EmissionDate ?? employeeStudy.EmissionDate;


            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeStudy.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
