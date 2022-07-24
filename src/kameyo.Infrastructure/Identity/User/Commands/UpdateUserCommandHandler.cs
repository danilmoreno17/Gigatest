using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Commands.Validators;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, Result<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UpdateUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Result<string>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            var validationResult = new UpdateUserCommandValidator(user != null)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            user.Email = request.Email ?? user.Email;
            user.PersonId = request.PersonId ?? user.PersonId;
            user.PersonTypeId = request.PersonTypeId ?? user.PersonTypeId;

            var resultUpdate = await _userManager.UpdateAsync(user);

            await UpdateRoles(user, request);

            if (!resultUpdate.Succeeded)
            {
                return Result<string>.PreconditionFailure(resultUpdate.Errors.MapToResultValidationFailure());
            }

            return Result<string>.Success(new List<string> { user.Id.ToString() }, HttpStatusCode.OK);
        }
        

        private async Task UpdateRoles(ApplicationUser user, UpdateUserCommandRequest request)
        {
            if (request.UserRoles == null) return;


            var userRolesCurrent = await _userManager.Users
                .Include(x => x.UserRoles)                
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id.ToString());

            var roles = _roleManager.Roles.AsNoTracking().ToList();            

            var userRolesRemove = userRolesCurrent
                .UserRoles
                .Select(x => x.RoleId)
                .Except(request.UserRoles.Select(x => x.RoleId));            

            var userRolesAdd = request.UserRoles.Select(x => x.RoleId) 
                .Except(userRolesCurrent
                .UserRoles
                .Select(x => x.RoleId));

            var rolesToRemove = roles
                .Where(x => userRolesRemove.Any(y => y.Equals(x.Id)))
                .Select(x => x.Name);

            var rolesToAdd = roles
                .Where(x => userRolesAdd.Any(y => y.Equals(x.Id)))
                .Select(x => x.Name);

            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            await _userManager.AddToRolesAsync(user, rolesToAdd);

        }
    }
}
