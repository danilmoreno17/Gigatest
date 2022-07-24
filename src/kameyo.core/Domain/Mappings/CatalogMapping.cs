using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class CatalogMapping
    {
        public CatalogMapping()
        { 
        }

        public static CatalogsDtoResponse MapToCatalogDTO(Kameyo.Core.Domain.Entities.Catalog entity) 
        {
            return new CatalogsDtoResponse
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                Name = entity.Name,
                Value = entity.Value,
                Description = entity.Description,                
                Order = entity.Order,
                IsSystemOwner = entity.IsSystemOwner,
                Status = entity.Status,
            };
        }
    }
}
