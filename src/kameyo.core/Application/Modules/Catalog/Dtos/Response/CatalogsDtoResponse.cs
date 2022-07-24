using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Catalog.Dtos.Response
{
    public class CatalogsDtoResponse
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; } = null!;
        public string? Owner { get; set; }
        public int Order { get; set; }
        public bool IsSystemOwner { get; set; } = false;
        public int? Status { get; set; }
    }
}
