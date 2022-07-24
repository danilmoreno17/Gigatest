using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class SubsidiaryConfiguration : IEntityTypeConfiguration<Subsidiary>
    {
        public void Configure(EntityTypeBuilder<Subsidiary> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("Subsidiary");

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

            builder.Property(e => e.PctPartIndrctCommissions)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

            builder.HasOne(d => d.Company)
                    .WithMany(p => p.Subsidiaries)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Subsidiary_Company");
           
        }
    }
}
