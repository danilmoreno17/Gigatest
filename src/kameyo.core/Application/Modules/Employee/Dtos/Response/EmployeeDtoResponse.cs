namespace Kameyo.Core.Application.Modules.Employee.Dtos.Response
{
    public class EmployeeDtoResponse
    {
        public Guid? Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? SubsidiaryId { get; set; }
        public string Names { get; set; } = null!;
        public string? LastName { get; set; }
        public string ? FullName { get; set; }
        public Guid? CatalogAreaId { get; set; }
        public Guid? CatalogDepartmentId { get; set; }
        public Guid? CatalogCostCenterId { get; set; }
        public Guid? CatalogPositionId { get; set; }
        public Guid? CatalogCurrencyId { get; set; }
        public Guid? CatalogEmployeeTypeId { get; set; }
        public decimal? CostHour { get; set; }
        public string? PhoneOffice { get; set; }
        public string? PhoneOfficeExt { get; set; }
        public string? PhoneMobile { get; set; }
        public decimal CalculateFactor { get; set; } = 1;
    }
}
