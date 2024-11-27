using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsBot.Infrastructure.Dal.EntityFramework.Configurations;

public class DrugConfigurations : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));

        builder.HasKey(x => x.Id);

        //TODO: добавть подгруску из drug в HasAnnotation название.
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
        //.HasAnnotation();

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.CountryCodeId)
            .IsRequired();

        builder.HasMany(x => x.DrugItems)
            .WithOne(d => d.Drug)
            .HasForeignKey(d => d.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}