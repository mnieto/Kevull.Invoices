using Kevull.Invoices.Entities;
using Microsoft.Data.Entity.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevull.Invoices.Persistence.Configuration {
    public class CustomerConfiguration {
        public CustomerConfiguration(EntityTypeBuilder<Customer> builder) {
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.FiscalIdentifier)
                .HasMaxLength(10);
            builder.Property(x => x.Street)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.City)
                .HasMaxLength(80)
                .IsRequired();
            builder.Property(x => x.PostalCode)
                .HasMaxLength(10);
            builder.Property(x => x.Region)
                .HasMaxLength(80);
        }
    }
}
