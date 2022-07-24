using Microsoft.AspNetCore.Identity;

namespace Kameyo.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
            Tokens = new HashSet<IdentityUserToken<string>>();
            UserRoles = new HashSet<ApplicationUserRole>();
        }

        public ApplicationUser(string userName) : this()
        {
            UserName = userName;
        }

        public Guid? PersonTypeId { get; set; }
        public Guid? PersonId { get; set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
