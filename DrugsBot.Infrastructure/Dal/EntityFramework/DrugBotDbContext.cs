using System.Reflection;
using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugsBot.Infrastructure.Dal.EntityFramework;

/// <summary>
/// Контекст базы данных для работы с сущностями.
/// </summary>
public class DrugBotDbContext : DbContext
{
    public DrugBotDbContext(DbContextOptions<DrugBotDbContext> options)
        : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<DrugStore> DrugStores { get; set; }
    public DbSet<DrugItem> DrugItems { get; set; }
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}