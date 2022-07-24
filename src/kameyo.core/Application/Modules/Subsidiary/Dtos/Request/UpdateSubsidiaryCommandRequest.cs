using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request
{
    public class UpdateSubsidiaryCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public Guid? CompanyId { get; set; } = default!;
        public Guid? CatalogTypeId { get; set; } = default!;
        public string? NumberId { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public Guid? CatalogRegionCountryId { get; set; } = default!;
        public Guid? CatalogRegionStateId { get; set; } = default!;
        public Guid? CatalogRegionCityId { get; set; } = default!;
        public string? Address { get; set; } = default!;
        public decimal? pctPartIndrctCommissions { get; set; } = default!;
    }
}
