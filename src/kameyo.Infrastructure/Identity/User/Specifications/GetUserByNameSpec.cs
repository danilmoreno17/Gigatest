using Ardalis.Specification;
using Kameyo.Infrastructure.Identity.Entities;

namespace Kameyo.Infrastructure.Identity.User.Specifications
{
    public class GetUserByNameSpec : Specification<ApplicationUser>
    {
        public GetUserByNameSpec(string userName)
        {
            Query
                .Where(x => x.UserName == userName && x.Active)
                .Include(x => x.UserRoles);
        }
    }
}
