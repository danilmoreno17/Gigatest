using Kameyo.Core.Application.Common.Mappings;
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
    public class GetUsersPaginationQueryHandler :
        IRequestHandler<GetUsersPaginationQueryRequest, ResultPaginated<UsersResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUsersPaginationQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultPaginated<UsersResponse>> Handle(GetUsersPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetUsersPaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<UsersResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var users = await _userManager.Users
                .Where(x => x.Active)
                .Select(x => UserMapping.MapToUserDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return users;
        }
    }
}
