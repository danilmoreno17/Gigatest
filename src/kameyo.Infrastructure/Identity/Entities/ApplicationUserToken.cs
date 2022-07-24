using Microsoft.AspNetCore.Identity;

namespace Kameyo.Infrastructure.Identity.Entities
{
    public class ApplicationUserToken: IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
