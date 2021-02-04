using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.User
{
    public class UserTest : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }
        private string _cpf { get; set; }
        private string _password { get; set; }

        [Fact(DisplayName = "Mantida a integridade do CRUD de usuário")]
        public async Task TestUser()
        {
            const string VALID_CPF = "12345678915";
            const string VALID_CPF_UPDATE = "51955314060";
            const string VALID_PASSWORD = "teste123";

            await CreateToken();
            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();
            _cpf = VALID_CPF;
            _password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            var userDto = new UserDto()
            {
                Name = _name,
                Email = _email,
                Cpf = _cpf,
                Password = _password
            };

            var result = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await result.Content.ReadAsStringAsync();
            var userId = JsonConvert.DeserializeObject<Guid>(postResult);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            Assert.False(userId == default(Guid));

            result = await client.GetAsync($"{hostApi}users");
            var getResult = await result.Content.ReadAsStringAsync();
            var resultList = JsonConvert.DeserializeObject<IEnumerable<UserDtoResult>>(getResult);
            Assert.NotNull(resultList);
            Assert.True(resultList.Count() > 0);
            Assert.True(resultList.Where(user => user.Id == userId).Count() == 1);

            var userDtoUpdate = new UserDto()
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Cpf = VALID_CPF_UPDATE,
                Password = _password
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(userDtoUpdate), Encoding.UTF8, "application/json");
            result = await client.PutAsync($"{hostApi}users/{userId}", stringContent);
            var putResult = await result.Content.ReadAsStringAsync();
            var resultUpdate = JsonConvert.DeserializeObject<UserDtoResult>(putResult);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotEqual(_name, resultUpdate.Name);
            Assert.NotEqual(_email, resultUpdate.Email);
            Assert.NotEqual(_cpf, resultUpdate.Cpf);

            result = await client.GetAsync($"{hostApi}users/{userId}");
            var getIdResult = await result.Content.ReadAsStringAsync();
            var resultGetId = JsonConvert.DeserializeObject<UserDtoResult>(getIdResult);
            Assert.NotNull(resultGetId);
            Assert.Equal(resultGetId.Name, resultUpdate.Name);
            Assert.Equal(resultGetId.Email, resultUpdate.Email);
            Assert.Equal(resultGetId.Cpf, resultUpdate.Cpf);

            result = await client.DeleteAsync($"{hostApi}users/{userId}");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
