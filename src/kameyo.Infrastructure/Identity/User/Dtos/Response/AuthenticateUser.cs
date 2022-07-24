using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Response
{
    public class AuthenticateUser
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PersonTypeId { get; set; }
        public string? PersonId { get; set; }
        
    }
}
