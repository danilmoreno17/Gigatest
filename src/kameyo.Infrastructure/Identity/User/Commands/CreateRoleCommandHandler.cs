using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Commands.Validators;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, Result<string>>
    {

        private readonly RoleManager<ApplicationRole> _roleManager;
        public CreateRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Result<string>> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var userExists = _roleManager.Roles.All(u => u.Name == request.Name);

            var validationResult = new CreateRoleCommandValidator(userExists)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var newRole = new ApplicationRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                NormalizedName = request.Name.ToUpper()
            };


            IdentityResult createResult = await _roleManager.CreateAsync(newRole);

            if (!createResult.Succeeded)
            {
                return Result<string>.PreconditionFailure(createResult.Errors.MapToResultValidationFailure());
            }

            var data = new List<string> { newRole.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }        
    }
}
