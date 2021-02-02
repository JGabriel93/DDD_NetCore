using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities.User;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioTest(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD user")]
        [Trait("CRUD", "UserEntity")]
        public async Task CrudUser()
        {
            const string VALID_CPF = "12345678909";
            const string ADMIN_NAME = "Admin";
            const string ADMIN_EMAIL = "admin@mail.com";
            const string ADMIN_CPF = "01194433502";

            using (var context = _serviceProvider.GetService<MyContext>())
            {
                var repository = new UserImplementation(context);
                var entity = new UserEntity
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    Cpf = VALID_CPF
                };

                var resultId = await repository.InsertAsync(entity);
                var user = await repository.SelectAsync(resultId);

                Assert.Equal(entity.Name, user.Name);
                Assert.Equal(entity.Email, user.Email);
                Assert.Equal(entity.Cpf, user.Cpf);
                Assert.False(resultId == Guid.Empty);

                entity.Name = Faker.Name.First();
                var resultAtt = await repository.UpdateAsync(entity, resultId);
                Assert.NotNull(resultAtt);
                Assert.Equal(entity.Name, resultAtt.Name);

                var exists = await repository.ExistsAsync(resultId);
                Assert.True(exists);

                var resultSelect = await repository.SelectAsync(resultId);
                Assert.NotNull(resultSelect);
                Assert.Equal(resultAtt.Name, resultSelect.Name);
                Assert.Equal(resultAtt.Email, resultSelect.Email);
                Assert.Equal(resultAtt.Cpf, resultSelect.Cpf);

                var resultSelectAll = await repository.SelectAllAsync();
                Assert.NotNull(resultSelectAll);
                Assert.True(resultSelectAll.Count() > 1);

                var removed = await repository.DeleteAsync(resultSelect.Id);
                Assert.True(removed);

                var standardUser = await repository.FindByLogin(ADMIN_EMAIL);
                Assert.Equal(ADMIN_NAME, standardUser.Name);
                Assert.Equal(ADMIN_EMAIL, standardUser.Email);
                Assert.Equal(ADMIN_CPF, standardUser.Cpf);
            }
        }
    }
}
