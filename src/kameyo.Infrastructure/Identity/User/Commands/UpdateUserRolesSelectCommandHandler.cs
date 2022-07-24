using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Commands
{
    public class UpdateUserRolesSelectCommandHandler : IRequestHandler<UpdateUserRolesSelectCommandRequest, Result<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UpdateUserRolesSelectCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Result<string>> Handle(UpdateUserRolesSelectCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var rol = await _roleManager.FindByIdAsync(request.RoleId.ToString());

            IdentityResult? resultUpdate = null;

            if (request.RoleSelected)
            {
                resultUpdate = await _userManager.AddToRoleAsync(user, rol.Name);
            }
            else
            {
                resultUpdate = await _userManager.RemoveFromRoleAsync(user, rol.Name);
            }

            if (!resultUpdate.Succeeded)
            {
                return Result<string>.PreconditionFailure(resultUpdate.Errors.MapToResultValidationFailure());
            }

            return Result<string>.Success(new List<string> { user.Id.ToString() }, HttpStatusCode.NoContent);


        }
    }
}
