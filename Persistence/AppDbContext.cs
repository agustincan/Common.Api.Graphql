using System;
using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Api.Graphql.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<CorrectiveAction> CorrectiveActions { get; set; }
        public DbSet<PreventiveAction> PreventiveActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("Common");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CorrectiveActionConfiguration(modelBuilder.Entity<CorrectiveAction>());
            new PreventiveActionConfiguration(modelBuilder.Entity<PreventiveAction>());
        }
    }
}
