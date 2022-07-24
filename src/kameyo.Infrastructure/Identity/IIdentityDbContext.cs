using Kameyo.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Infrastructure.Identity
{
    public interface IIdentityDbContext
    {
        DbSet<ApplicationUser> IdentityUsers { get; set; }
        //DbSet<ApplicationUserRole> IdentityUserRoles { get; set; }
    }
}
