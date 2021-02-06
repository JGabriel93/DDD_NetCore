using System;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public static class SeedData
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            SeedUser(modelBuilder);
            SeedCurrentAccount(modelBuilder);
        }

        public static void SeedUser(ModelBuilder modelBuilder)
        {
            var dateUtcNow = DateTime.UtcNow;

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"),
                Name = "João",
                Email = "admin@mail.com",
                Cpf = "01194433502",
                Password = BCrypt.Net.BCrypt.HashPassword("admin", BCrypt.Net.BCrypt.GenerateSalt()),
                CreateAt = dateUtcNow,
                UpdateAt = null
            });

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = new Guid("b171c698-abec-418c-9357-80d0b9199d1c"),
                Name = "José",
                Email = "jose@mail.com",
                Cpf = "26687020544",
                Password = BCrypt.Net.BCrypt.HashPassword("jose1234", BCrypt.Net.BCrypt.GenerateSalt()),
                CreateAt = dateUtcNow,
                UpdateAt = null
            });
        }

        public static void SeedCurrentAccount(ModelBuilder modelBuilder)
        {
            var dateUtcNow = DateTime.UtcNow;

            modelBuilder.Entity<CurrentAccountEntity>().HasData(new CurrentAccountEntity
            {
                Id = new Guid("f7f8325d-7dab-425b-a59d-2e25f5354c62"),
                Balance = 1000,
                UserId = new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"),
                CreateAt = dateUtcNow,
                UpdateAt = dateUtcNow
            });

            modelBuilder.Entity<HistoricCurrentAccountEntity>().HasData(new HistoricCurrentAccountEntity
            {
                Id = Guid.NewGuid(),
                Movement = "D",
                AmountMoved = 1000,
                CurrentAccountId = new Guid("f7f8325d-7dab-425b-a59d-2e25f5354c62"),
                CreateAt = dateUtcNow
            });

            modelBuilder.Entity<CurrentAccountEntity>().HasData(new CurrentAccountEntity
            {
                Id = new Guid("cee743f5-513c-4464-98d2-6e8dfaba1038"),
                Balance = 0,
                UserId = new Guid("b171c698-abec-418c-9357-80d0b9199d1c"),
                CreateAt = dateUtcNow,
                UpdateAt = dateUtcNow
            });
        }
    }
}
