using System;
using CustomerRegistration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerRegistration.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Gender).IsFixedLength(true).HasMaxLength(1).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(80).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();

            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Pedro",
                    BirthDate = new DateTime(1999, 01, 28),
                    Gender = "M",
                    ZipCode = "86975000",
                    Address = "Rua José Francisco da Mata",
                    Number = 77,
                    Area = "Jardim das Torres",
                    City = "Mandaguari",
                    State = "PR"
                });
        }
    }
}