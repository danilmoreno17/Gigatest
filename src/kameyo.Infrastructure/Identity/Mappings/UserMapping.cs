using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.Models.Dtos.Request;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;

namespace Kameyo.Infrastructure.Identity.Mappings
{
    public class UserMapping
    {
        public UserMapping()
        {

        }

        public static UsersResponse MapToUserDTO(ApplicationUser entity)
        {
            return new UsersResponse
            {
                Id = entity.Id,

                PersonTypeId = entity.PersonTypeId,
                PersonId = entity.PersonId,
                Email = entity.Email,
                EmailConfirmed = entity.EmailConfirmed,
            };
        }

        public void UpdateUserEntity(ApplicationUser entity, UsersUpdateDtoRequest dto)
        {
            entity.Email = dto.Email;
            entity.PersonId = dto.PersonId;
            entity.PersonTypeId = dto.PersonTypeId;
        }
    }
}
