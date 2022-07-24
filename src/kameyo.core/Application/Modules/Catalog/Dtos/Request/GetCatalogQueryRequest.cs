using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Catalog.Dtos.Request
{
    public class GetCatalogQueryRequest : IRequest<Result<CatalogsDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
