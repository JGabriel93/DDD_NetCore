using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.CurrentAccount;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Api.Domain.Models.CurrentAccount;
using Api.Domain.Models.User;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CurrentAccountMapper : BaseTest
    {
        [Fact(DisplayName = "Mantida a integridade dos mapeamentos de conta corrente")]
        public void TestMapper()
        {
            const string VALID_CPF = "12345678909";
            const string VALID_PASSWORD = "teste123";

            var password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            var listEntityUsers = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var user = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    Cpf = VALID_CPF,
                    Password = password
                };

                listEntityUsers.Add(user);
            }

            var listEntityCurrentAccounts = new List<CurrentAccountEntity>();
            foreach (var user in listEntityUsers)
            {
                var entityCurrentAccount = new CurrentAccountEntity
                {
                    Id = Guid.NewGuid(),
                    Balance = 100,
                    UserId = user.Id
                };

                listEntityCurrentAccounts.Add(entityCurrentAccount);
            }

            var modelUser = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Cpf = VALID_CPF,
                Password = password
            };

            var modelCurrentAccount = new CurrentAccountModel
            {
                Id = Guid.NewGuid(),
                Balance = 100,
                UserId = modelUser.Id
            };

            var entity = Mapper.Map<CurrentAccountEntity>(modelCurrentAccount);
            Assert.Equal(entity.Id, modelCurrentAccount.Id);
            Assert.Equal(entity.Balance, modelCurrentAccount.Balance);
            Assert.Equal(entity.UserId, modelCurrentAccount.UserId);

            var dto = Mapper.Map<CurrentAccountDtoResult>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Balance, entity.Balance);
            Assert.Equal(dto.UserId, entity.UserId);

            var listEntityToListDto = Mapper.Map<List<CurrentAccountDtoResult>>(listEntityCurrentAccounts);
            Assert.True(listEntityToListDto.Count() == listEntityCurrentAccounts.Count());
            for (int i = 0; i < listEntityToListDto.Count(); i++)
            {
                Assert.Equal(listEntityToListDto[i].Id, listEntityCurrentAccounts[i].Id);
                Assert.Equal(listEntityToListDto[i].Balance, listEntityCurrentAccounts[i].Balance);
                Assert.Equal(listEntityToListDto[i].UserId, listEntityCurrentAccounts[i].UserId);
            }

            var userDtoResult = Mapper.Map<CurrentAccountDtoResult>(entity);
            Assert.Equal(userDtoResult.Id, entity.Id);
            Assert.Equal(userDtoResult.Balance, entity.Balance);
            Assert.Equal(userDtoResult.UserId, entity.UserId);
        }
    }
}
