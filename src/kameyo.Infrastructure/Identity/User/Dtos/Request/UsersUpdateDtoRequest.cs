using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Infrastructure.Identity.Models.Dtos.Request
{
    public class UsersUpdateDtoRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Guid? PersonTypeId { get; set; } = null;
        public Guid? PersonId { get; set; } = null;

    }
}
