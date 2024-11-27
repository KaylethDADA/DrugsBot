using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsBot.Infrastructure.Dal.EntityFramework.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));
        
        builder.HasKey(ds => ds.Id);

        builder.HasIndex(ds => new { ds.DrugNetwork, ds.Number })
            .IsUnique();

        builder.Property(ds => ds.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ds => ds.Number)
            .IsRequired();

        builder.OwnsOne(ds => ds.Address, a =>
        {
            a.Property(address => address.City)
                .IsRequired()
                .HasMaxLength(50);
            a.Property(address => address.Street)
                .IsRequired()
                .HasMaxLength(100);
            a.Property(address => address.House)
                .IsRequired()
                .HasMaxLength(10);
            a.Property(address => address.CountryCode)
                .IsRequired()
                .HasMaxLength(2);
        });

        builder.HasMany(ds => ds.DrugItems)
            .WithOne(di => di.DrugStore)
            .HasForeignKey(di => di.DrugStoreId);
    }
}