using Ardalis.Specification;
using Kameyo.Infrastructure.Identity.Entities;

namespace Kameyo.Infrastructure.Identity.User.Specifications
{
    public class GetUserByIdSpec : Specification<ApplicationUser>
    {
        public GetUserByIdSpec(string userId)
        {
            Query                
                .Include(x => x.UserRoles)
                .Where(x => x.Id == userId)
                .AsNoTracking();
            
        }
    }
}
