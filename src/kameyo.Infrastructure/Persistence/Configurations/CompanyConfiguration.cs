using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.ToTable("Company");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.NumberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            

        }
    }
}
