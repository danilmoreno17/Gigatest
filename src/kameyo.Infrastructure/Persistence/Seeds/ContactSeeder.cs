using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Seeds
{
    public class ContactSeeder : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            var dataSource = new List<Contact>() { };

            dataSource.Add(new Contact { Id = new Guid("95147ae2-93ee-43fd-acf0-d5eb248a597d"), CustomerId = new Guid("80f19c33-2a57-4767-8a1e-c58e0ebfd6fb"), Names = "Contact 1", LastName = "Contact 1", Email = "contact1@mail.com", Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Contact { Id = new Guid("f234e182-b274-4109-bacf-3edc0d6d6ab8"), CustomerId = new Guid("80f19c33-2a57-4767-8a1e-c58e0ebfd6fb"), Names = "Contact 1.1", LastName = "Contact 1.1", Email = "contact1_1@mail.com", Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new Contact { Id = new Guid("aaf570a8-39da-4c43-bcce-11f92a7e025c"), CustomerId = new Guid("f1b98eda-a3f0-4006-b947-1cd45ffd2cac"), Names = "Contact 2", LastName = "Contact 2", Email = "contact1@mail.com", Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Contact { Id = new Guid("f1e66b7a-3e34-4df8-ab10-f372ea2ba8d6"), CustomerId = new Guid("f1b98eda-a3f0-4006-b947-1cd45ffd2cac"), Names = "Contact 2.1", LastName = "Contact 2.1", Email = "contact2_1@mail.com", Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            builder.HasData(dataSource);
        }
    }
}
