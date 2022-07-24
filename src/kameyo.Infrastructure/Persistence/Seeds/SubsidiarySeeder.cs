using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Seeds
{
    public class SubsidiarySeeder : IEntityTypeConfiguration<Subsidiary>
    {
        public void Configure(EntityTypeBuilder<Subsidiary> builder)
        {
            var dataSource = new List<Subsidiary>() { };

            dataSource.Add(new Subsidiary { Id = new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5"), CompanyId = new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), CatalogTypeId = new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), NumberId = "123456789", Name = "Giga Ecuador", CatalogRegionCountryId = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), CatalogRegionStateId = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), CatalogRegionCityId = new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), Address = "Address", Created = DateTime.UtcNow, CreatedBy = "System" });
            dataSource.Add(new Subsidiary { Id = new Guid("6ea91b88-a679-4864-bc0c-853e2c92c91e"), CompanyId = new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), CatalogTypeId = new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), NumberId = "123456789", Name = "Giga Colombia", CatalogRegionCountryId = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), CatalogRegionStateId = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), CatalogRegionCityId = new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), Address = "Address", Created = DateTime.UtcNow, CreatedBy = "System" });
            dataSource.Add(new Subsidiary { Id = new Guid("0a206aab-bc50-4683-be7b-f6adf4ad1209"), CompanyId = new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), CatalogTypeId = new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), NumberId = "123456789", Name = "Giga El Salvador", CatalogRegionCountryId = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), CatalogRegionStateId = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), CatalogRegionCityId = new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), Address = "Address", Created = DateTime.UtcNow, CreatedBy = "System" });

            builder.HasData(dataSource);
        }
    }
}
