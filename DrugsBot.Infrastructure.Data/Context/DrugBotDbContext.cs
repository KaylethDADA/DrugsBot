using DrugsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DrugsBot.Infrastructure.Data.Context
{
    public class DrugBotDbContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugStore> DrugStores { get; set; }
        public DbSet<DrugItem> DrugItems { get; set; }
        public DbSet<Country> Countries { get; set; }


        public DrugBotDbContext(DbContextOptions<DrugBotDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
