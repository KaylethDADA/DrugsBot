using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugsBot.Infrastructure.Dal.EntityFramework.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(p => p.ExternalId)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(p => p.Email)
            .IsRequired(false);
        
        builder.HasMany(p => p.FavoriteDrugs)
            .WithOne(f => f.Profile)
            .HasForeignKey(f => f.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}