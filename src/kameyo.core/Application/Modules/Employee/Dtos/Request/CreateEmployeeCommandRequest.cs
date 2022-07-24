using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Employee.Dtos.Request
{
    public class CreateEmployeeCommandRequest : IRequest<Result<string>>
    {
        public Guid? ParentId { get; set; }
        public Guid SubsidiaryId { get; set; }
        public string Names { get; set; } = null!;
        public string? LastName { get; set; }
        public Guid? CatalogAreaId { get; set; }
        public Guid? CatalogDepartmentId { get; set; }
        public Guid? CatalogCostCenterId { get; set; }
        public Guid? CatalogPositionId { get; set; }
        public Guid? CatalogCurrencyId { get; set; }
        public Guid? CatalogEmployeeTypeId { get; set; }
        public decimal CostHour { get; set; }
        public string? PhoneOffice { get; set; }
        public string? PhoneOfficeExt { get; set; }
        public string? PhoneMobile { get; set; }
        public decimal CalculateFactor { get; set; } = 1;
    }
}
