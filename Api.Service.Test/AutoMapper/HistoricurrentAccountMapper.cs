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
    public class HistoricurrentAccountMapper : BaseTest
    {
        [Fact(DisplayName = "Mantida a integridade dos mapeamentos do histórico de conta corrente")]
        public void TestMapper()
        {
            const string VALID_CPF = "12345678909";
            const string VALID_PASSWORD = "teste123";

            var password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

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

            var modelHistoricCurrentAccount = new HistoricCurrentAccountModel
            {
                Id = Guid.NewGuid(),
                Movement = "D",
                AmountMoved = 100,
                CurrentAccountId = modelCurrentAccount.Id
            };

            var listEntityHistoricCurrentAccounts = new List<HistoricCurrentAccountEntity>();
            for (int i = 0; i < 5; i++)
            {
                var entityHistoricCurrentAccount = new HistoricCurrentAccountEntity
                {
                    Id = Guid.NewGuid(),
                    Movement = "D",
                    AmountMoved = 100,
                    CurrentAccountId = modelCurrentAccount.Id
                };

                listEntityHistoricCurrentAccounts.Add(entityHistoricCurrentAccount);
            }

            var entity = Mapper.Map<HistoricCurrentAccountEntity>(modelHistoricCurrentAccount);
            Assert.Equal(entity.Id, modelHistoricCurrentAccount.Id);
            Assert.Equal(entity.Movement, modelHistoricCurrentAccount.Movement);
            Assert.Equal(entity.AmountMoved, modelHistoricCurrentAccount.AmountMoved);
            Assert.Equal(entity.CurrentAccountId, modelHistoricCurrentAccount.CurrentAccountId);

            var dto = Mapper.Map<HistoricCurrentAccountDtoResult>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Movement, entity.Movement);
            Assert.Equal(dto.AmountMoved, entity.AmountMoved);
            Assert.Equal(dto.CurrentAccountId, entity.CurrentAccountId);

            var listEntityToListDto = Mapper.Map<List<HistoricCurrentAccountDtoResult>>(listEntityHistoricCurrentAccounts);
            Assert.True(listEntityToListDto.Count() == listEntityHistoricCurrentAccounts.Count());
            for (int i = 0; i < listEntityToListDto.Count(); i++)
            {
                Assert.Equal(listEntityToListDto[i].Id, listEntityHistoricCurrentAccounts[i].Id);
                Assert.Equal(listEntityToListDto[i].Movement, listEntityHistoricCurrentAccounts[i].Movement);
                Assert.Equal(listEntityToListDto[i].AmountMoved, listEntityHistoricCurrentAccounts[i].AmountMoved);
                Assert.Equal(listEntityToListDto[i].CurrentAccountId, listEntityHistoricCurrentAccounts[i].CurrentAccountId);
            }

            var userDtoResult = Mapper.Map<HistoricCurrentAccountDtoResult>(entity);
            Assert.Equal(userDtoResult.Id, entity.Id);
            Assert.Equal(userDtoResult.Movement, entity.Movement);
            Assert.Equal(userDtoResult.AmountMoved, entity.AmountMoved);
            Assert.Equal(userDtoResult.CurrentAccountId, entity.CurrentAccountId);
        }
    }
}
