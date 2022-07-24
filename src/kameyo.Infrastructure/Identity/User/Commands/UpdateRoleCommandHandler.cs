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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, Result<string>>
    {

        private readonly RoleManager<ApplicationRole> _roleManager;
        public UpdateRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Result<string>> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());

            var validationResult = new UpdateRoleCommandValidator(role != null)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            role.Name = request.Name;
            role.NormalizedName = request.Name.ToUpper();

            var resultUpdate = await _roleManager.UpdateAsync(role);

            if (!resultUpdate.Succeeded)
            {
                return Result<string>.PreconditionFailure(resultUpdate.Errors.MapToResultValidationFailure());
            }

            return Result<string>.Success(new List<string> { role.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
