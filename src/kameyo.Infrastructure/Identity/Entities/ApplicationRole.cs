using Microsoft.AspNetCore.Identity;

namespace Kameyo.Infrastructure.Identity.Entities
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid().ToString();
            UserRoles = new HashSet<ApplicationUserRole>();
            RoleClaims = new HashSet<IdentityRoleClaim<string>>();
        }
        public ApplicationRole(string roleName) : this()
        {
            Name = roleName;
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<IdentityRoleClaim<string>> RoleClaims { get; set; }
    }
}
