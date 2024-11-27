using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsBot.Infrastructure.Dal.EntityFramework.Configurations;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));
        
        builder.HasIndex(f => new { f.ProfileId, f.DrugId })
            .IsUnique();
        
        builder.Property(f => f.ProfileId)
            .IsRequired();

        builder.Property(f => f.DrugId)
            .IsRequired();
        
        builder.Property(f => f.DrugStoreId)
            .IsRequired(false);
    }
}