using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Common.Enums
{
    public class RolEnum
    {
        public RolEnum(Guid id, string name, string normalizedName)
        {
            Id = id;
            Name = name;
            NormalizedName = normalizedName;
        }
        public Guid Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual string NormalizedName { get; set; } = string.Empty;
    }
}
