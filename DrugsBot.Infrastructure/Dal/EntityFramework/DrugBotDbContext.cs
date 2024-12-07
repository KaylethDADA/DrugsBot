using System.Reflection;
using DrugsBot.Domain.Entities;
using DrugsBot.Infrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DrugsBot.Infrastructure.Dal.EntityFramework;

/// <summary>
/// Контекст базы данных для работы с сущностями.
/// </summary>
public class DrugBotDbContext : DbContext
{
    private readonly DataBaseSettings _options;

    public DrugBotDbContext(IOptions<DataBaseSettings> options)
    {
        _options = options.Value;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_options.ConnectionStrings, options =>
        {
            options.CommandTimeout(_options.CommandTimeout);
        });
    }
}