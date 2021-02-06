using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test.CurrentAccount
{
    public class CurrentAccountTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CurrentAccountTest(DbTest dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Mantida a integridade do CRUD de conta corrente")]
        [Trait("CRUD", "CurrentAccountEntity")]
        public async Task CrudCurrentAccountTest()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                const decimal CREDIT_AMOUNT = 50;
                const decimal INITIAL_CREDIT = 0;
                const string VALID_CPF = "12345678909";
                const string VALID_PASSWORD = "teste123";

                var repositoryCurrentAccount = new CurrentAccountImplementation(context);
                var repositoryHistoricCurrentAccount = new HistoricCurrentAccountImplementation(context);
                var repositoryUser = new UserImplementation(context);

                var entityUser = new UserEntity
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    Cpf = VALID_CPF,
                    Password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt())
                };
                var resultUserId = await repositoryUser.InsertAsync(entityUser);

                var entityCurrentAccount = new CurrentAccountEntity()
                {
                    Id = Guid.NewGuid(),
                    Balance = INITIAL_CREDIT,
                    UserId = resultUserId
                };
                var resultCurrentAccountId = await repositoryCurrentAccount.InsertAsync(entityCurrentAccount);
                Assert.False(resultCurrentAccountId == Guid.Empty);

                entityCurrentAccount = new CurrentAccountEntity()
                {
                    Balance = CREDIT_AMOUNT,
                    UserId = resultUserId
                };
                var resultCurrentAccount = await repositoryCurrentAccount.UpdateAsync(entityCurrentAccount, resultCurrentAccountId);
                Assert.NotNull(resultCurrentAccount);

                var entityHistoricCurrentAccount = new HistoricCurrentAccountEntity()
                {
                    Id = Guid.NewGuid(),
                    Movement = "D",
                    AmountMoved = CREDIT_AMOUNT,
                    CurrentAccountId = resultCurrentAccountId
                };
                var resultHistoricCurrentAccountId = await repositoryHistoricCurrentAccount.InsertAsync(entityHistoricCurrentAccount);
                Assert.False(resultCurrentAccountId == Guid.Empty);

                var resultCurrentAccountSelect = await repositoryCurrentAccount.SelectAsync(resultCurrentAccountId);
                Assert.NotNull(resultCurrentAccountSelect);

                var resultHistoricCurrentAccountSelect = await repositoryHistoricCurrentAccount.SelectAsync(resultHistoricCurrentAccountId);
                Assert.NotNull(resultHistoricCurrentAccountSelect);

                var resultCurrentAccountSelectAll = await repositoryCurrentAccount.SelectAllAsync();
                Assert.NotNull(resultCurrentAccountSelectAll);
                Assert.True(resultCurrentAccountSelectAll.Count() > 2);

                var resultHistoricCurrentAccountSelectAll = await repositoryHistoricCurrentAccount.SelectAllAsync();
                Assert.NotNull(resultHistoricCurrentAccountSelectAll);
                Assert.True(resultHistoricCurrentAccountSelectAll.Count() > 1);
            }
        }
    }
}
