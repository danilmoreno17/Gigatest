using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Dtos;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using Microsoft.AspNetCore.Identity;

namespace Kameyo.Infrastructure.Identity.Mappings
{
    public static class IdentityMappingExtensions
    {
        public static UsersResponse MapToUserDTO(this ApplicationUser entity)
        {
            return new UsersResponse()
            {
                Id = entity.Id,
                Email = entity.Email,
                PersonTypeId = entity.PersonTypeId,
                PersonId = entity.PersonId,
                EmailConfirmed = entity.EmailConfirmed,
                UserRoles = entity.UserRoles.MapToUserRolesDto()
            };
        }

        public static List<UsersResponse> MapToUserDTO(this IEnumerable<ApplicationUser> entities)
        {
            var result = new List<UsersResponse>();

            foreach (var entity in entities)
            {
                result.Add(new UsersResponse
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    PersonTypeId = entity.PersonTypeId,
                    PersonId = entity.PersonId,
                    EmailConfirmed = entity.EmailConfirmed,
                    UserRoles = entity.UserRoles.MapToUserRolesDto()
                }); ;
            }

            return result;
        }
        public static async Task<List<string>> GetUserRoles(this ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            return new List<string>(await userManager.GetRolesAsync(user));
        }
        public static List<UserRolesDto> MapToUserRolesDto(this ICollection<ApplicationUserRole> userRoles)
        {
            var result = new List<UserRolesDto>();
            foreach (var item in userRoles)
            {
                result.Add(new UserRolesDto()
                {
                    UserId = item.UserId,
                    RoleId = item.RoleId
                });
            }
            return result;
        }

        public static List<RolesResponse> MapToRoleDTO(this IEnumerable<ApplicationRole> entities)
        {
            var result = new List<RolesResponse>();

            foreach (var entity in entities)
            {
                result.Add(new RolesResponse
                {
                    Id = entity.Id,
                    Name = entity.Name
                }); ;
            }

            return result;
        }

        public static List<UserRolesSelectResponse> MapToUserRolesSelect(
            this IEnumerable<ApplicationRole> entities, string userId, IEnumerable<ApplicationUserRole> userRoles) {

            var result = new List<UserRolesSelectResponse>();

            foreach (var entity in entities)
            {
                result.Add(new UserRolesSelectResponse
                {
                    UserId = userId,
                    RoleId = entity.Id,
                    RoleName = entity.Name,
                    RoleSelected = userRoles.Select(x => x.RoleId).Contains(entity.Id)

                });
            }

            return result;
        }        
    }
}
