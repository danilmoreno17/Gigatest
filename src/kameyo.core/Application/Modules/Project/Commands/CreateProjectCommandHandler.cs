using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using MediatR;
using System.Net;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Modules.Project.Commands.Validators;

namespace Kameyo.Core.Application.Modules.Project.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken)
        {

            var projectExits = false;
            if (_context.Projects.Count() > 0) 
            {
                projectExits = _context.Projects.All(z => z.Name == request.Name && z.Active);
            }
            if (projectExits)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El nombre del proyecto ya existe",
                        Name=""
                    }
                });
            }

            /*var validationResult = await new CreateProjectCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/


            var newProject = new Domain.Entities.Project()
            {
                CustomerId = request.CustomerId,
                Name = request.Name,
                Description = request.Description,
                CatalogProjectTypeId = request.CatalogProjectTypeId,
                CatalogProjectCategoryId = request.CatalogProjectCategoryId,
                CatalogProjectStateId = request.CatalogProjectStateId,
                MainContactId = request.MainContactId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                DurationHour = request.DurationHour,
                CloseDate = request.CloseDate,
                CostHourMenCustomer = request.CostHourMenCustomer,
                CostHourMenProject = request.CostHourMenProject,
                
            };

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync(cancellationToken);

            var data = new List<string>() { newProject.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
