using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
public class SubsidiariesDtoResponse
{
    public Guid Id { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? CatalogTypeId { get; set; }
    public string? NumberId { get; set; }
    public string? Name { get; set; }
    public Guid? CatalogRegionCountryId { get; set; }
    public Guid? CatalogRegionStateId { get; set; }
    public Guid? CatalogRegionCityId { get; set; }
    public string? Address { get; set; }
    public decimal? PctPartIndrctCommissions { get; set; }
}