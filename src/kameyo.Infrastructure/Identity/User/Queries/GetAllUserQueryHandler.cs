using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.Mappings;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Infrastructure.Identity.User.Queries
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, Result<UsersResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetAllUserQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<UsersResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users
                .Where(x => x.Active)
                .Select(x => UserMapping.MapToUserDTO(x))
                .AsNoTracking()
                .ToListAsync();

            return Result<UsersResponse>.Success(users, HttpStatusCode.OK);
        }
    }
}
