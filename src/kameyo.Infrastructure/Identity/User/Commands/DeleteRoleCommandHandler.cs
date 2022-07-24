using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Commands.Validators;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, Result<string>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        public DeleteRoleCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());

            var userRoles = await _userManager.Users
                .Include(x => x.UserRoles)
                .Where(x => x.UserRoles.Select(x => x.RoleId).Any(x => x.Equals(request.Id)))
                .ToListAsync();

            var validationResult = new DeleteRoleCommandValidator(role != null)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            await RemoveRolFromUser(role, userRoles);
            await RemoveClaims(role);
            await RemoveMenuRol(request, cancellationToken);

            var resultUpdate = await _roleManager.DeleteAsync(role);

            if (!resultUpdate.Succeeded)
            {
                return Result<string>.PreconditionFailure(resultUpdate.Errors.MapToResultValidationFailure());
            }

            return Result<string>.Success(new List<string> { role.Id.ToString() }, HttpStatusCode.OK);
        }

        private async Task RemoveRolFromUser(ApplicationRole role, List<ApplicationUser> userRoles)
        {
            foreach (var user in userRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
        }

        private async Task RemoveClaims(ApplicationRole role)
        {
            var claims = await _roleManager.GetClaimsAsync(role);

            foreach (var item in claims)
            {
                await _roleManager.RemoveClaimAsync(role, item);
            }
        }

        private async Task RemoveMenuRol(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var menuRole = _dbContext.MenuRole
                .Where(x => x.RoleId == new Guid(request.Id))
                .ToList();

            _dbContext.MenuRole.RemoveRange(menuRole);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
