using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Response;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Queries
{
    public class GetEmployeeSkillAbilityQueryHandler : IRequestHandler<GetEmployeeSkillAbilityQueryRequest, Result<EmployeeSkillAbilitiesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_EMPLOYEEID = "EMPLOYEEID";

        public GetEmployeeSkillAbilityQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<EmployeeSkillAbilitiesDtoResponse>> Handle(GetEmployeeSkillAbilityQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var employeeSkillAbilitys = await _dbContext.EmployeeSkillAbilities
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => EmployeeSkillAbilityMapping.MapToEmployeeSkillAbilityDTO(x))
                .ToListAsync(cancellationToken);
            if (employeeSkillAbilitys == null) return Result<EmployeeSkillAbilitiesDtoResponse>.NotFound();
            return Result<EmployeeSkillAbilitiesDtoResponse>.Success(employeeSkillAbilitys);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.EmployeeSkillAbility> GetSpecification(GetEmployeeSkillAbilityQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.EmployeeSkillAbility> specification = new GetEmployeeSkillAbilityByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_EMPLOYEEID)
            {
                specification = new GetEmployeeSkillAbilitiesByEmployeeIdSpec(request.Value);
            }
            return specification;
        }
    }
}
