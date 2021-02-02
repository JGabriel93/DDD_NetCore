using System;
using Api.Data.Mapping;
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

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Email = "admin@mail.com",
                Cpf = "01194433502",
                CreateAt = DateTime.UtcNow,
                UpdateAt = null
            });
        }
    }
}
