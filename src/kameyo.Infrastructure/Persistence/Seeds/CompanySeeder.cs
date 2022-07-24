using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Seeds
{
    public class CompanySeeder : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            var dataSource = new List<Company>();
            dataSource.Add(new Company
            {
                Id = new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"),                
                CatalogTypeId=new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"),
                NumberId="123456789",
                Name = "Giga",
                CatalogRegionCountryId= new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"),
                CatalogRegionStateId= new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"),
                CatalogRegionCityId= new Guid("4a4dfebf-6cd4-42bb-aeee-36775ec5b70c"),
                Address ="Address",
                Created = DateTime.UtcNow,
                CreatedBy = "System",                
                Active = true
            });

            builder.HasData(dataSource);
        }
    }
}
