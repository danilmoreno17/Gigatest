using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.ToTable("Contact");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");


            builder.Property(e => e.Area)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Department)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Names)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.PhoneMobile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.PhoneOffice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.PhoneOfficeExt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Position)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Contact_Customer");
            

        }
    }
}
