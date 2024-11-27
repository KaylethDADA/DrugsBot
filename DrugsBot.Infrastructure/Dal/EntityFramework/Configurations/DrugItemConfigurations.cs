using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsBot.Infrastructure.Dal.EntityFramework.Configurations;

public class DrugItemConfigurations : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));

        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => new { x.DrugId, x.DrugStoreId })
            .IsUnique();
        
        builder.Property(x => x.DrugId)
            .IsRequired();

        builder.Property(x => x.DrugStoreId)
            .IsRequired();

        builder.Property(x => x.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Count)
            .IsRequired()
            .HasColumnType("float");
    }
}