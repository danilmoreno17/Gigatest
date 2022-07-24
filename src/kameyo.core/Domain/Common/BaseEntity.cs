using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kameyo.Core.Domain.Common
{
    public abstract class BaseEntity : AuditableEntity
    {
        [Key, Column(Order = 0)]
        public Guid Id { get; set; }
        
        public bool Active { get; set; } = true;

    }
}
