using System;
using Api.Data.Mapping;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<CurrentAccountEntity>(new CurrentAccountMap().Configure);
            modelBuilder.Entity<HistoricCurrentAccountEntity>(new HistoricCurrentAccountMap().Configure);

            SeedData.Seeding(modelBuilder);
        }
    }
}
