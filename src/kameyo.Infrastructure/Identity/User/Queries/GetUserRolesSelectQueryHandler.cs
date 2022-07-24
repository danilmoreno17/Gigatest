using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.Mappings;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Infrastructure.Identity.User.Queries
{
    public class GetUserRolesSelectQueryHandler : IRequestHandler<GetUserRolesSelectQueryRequest, Result<UserRolesSelectResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public GetUserRolesSelectQueryHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<UserRolesSelectResponse>> Handle(GetUserRolesSelectQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles
                .AsNoTracking()
                .ToListAsync();

            var user = await _userManager.Users
                .Include(x => x.UserRoles)
                .Where(x => x.Id == request.UserId.ToString())
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var userRoles = (user == null ? new List<ApplicationUserRole>() : user.UserRoles);

            var userRolesSelectResponse = roles.MapToUserRolesSelect(request.UserId.ToString(), userRoles);

            return Result<UserRolesSelectResponse>.Success(userRolesSelectResponse);



        }
    }
}
