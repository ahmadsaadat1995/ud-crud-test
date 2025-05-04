using CRM.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Persistence.Configurations.Customers;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(it => it.Id);

        builder.Property(it => it.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(it => it.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(it => it.NationalCode)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(it => it.PhoneNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(it => it.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}
