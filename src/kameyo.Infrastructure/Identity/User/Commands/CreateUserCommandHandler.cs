using Kameyo.Core.Application.Common.Enums;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Result<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Result<string>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var userExists = _userManager.Users.All(u => u.UserName == request.Email && u.Active);
            
            var validationResult = new CreateUserCommandValidator(userExists)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }                        

            var newUser = MapDtoRequestToApplicationUser(request);
            IdentityResult createResult;
            createResult = await _userManager.CreateAsync(newUser, request.Password);

            if (!createResult.Succeeded)
            {
                return Result<string>.PreconditionFailure(createResult.Errors.MapToResultValidationFailure());
            }

            await AddRolesToUserAsync(newUser, request);

            var data = new List<string>
            {
                newUser.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }

        private static ApplicationUser MapDtoRequestToApplicationUser(CreateUserCommandRequest request)
        {

            return new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Email,
                Email = request.Email,
                PersonId = request.PersonId,
                PersonTypeId = request.PersonTypeId ?? UsersTypeEnum.User.Id, 
                EmailConfirmed = false
            };
        }

        private async Task<IdentityResult> AddRolesToUserAsync(ApplicationUser user, CreateUserCommandRequest request)
        {
            if (request.UserRoles.Count == 0) return new IdentityResult();

            var roles = await _roleManager.Roles.ToListAsync();

            var rolesToAdd = roles
                .Where(x => request.UserRoles.Select(x => x.RoleId).Contains(x.Id))
                .Select(x => x.Name).ToList();

            return await _userManager.AddToRolesAsync(user, rolesToAdd);
        }
    }
}
