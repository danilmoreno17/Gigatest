using Ardalis.Specification;
using Kameyo.Infrastructure.Identity.Entities;

namespace Kameyo.Infrastructure.Identity.User.Specifications
{
    public class GetUserByEmailSpec : Specification<ApplicationUser>
    {
        public GetUserByEmailSpec(string email)
        {
            Query
                .Where(x => x.Email == email && x.Active)
                .Include(x => x.UserRoles);
        }
    }
}
