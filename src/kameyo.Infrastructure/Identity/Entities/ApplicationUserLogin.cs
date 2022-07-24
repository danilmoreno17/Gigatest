using Microsoft.AspNetCore.Identity;

namespace Kameyo.Infrastructure.Identity.Entities
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
