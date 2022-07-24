using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {

            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("Catalog");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");

            builder.Property(e => e.Order).HasColumnName("order");            

            builder.Property(e => e.ParentId).HasColumnName("parent_id");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.Value)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("value");

            builder.Property(e => e.Value1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("value1");

            builder.Property(e => e.Value2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("value2");


        }
    }
}
