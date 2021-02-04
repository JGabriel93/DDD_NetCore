using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public Guid Id { get; set; }
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string Cpf { get; set; }
        public static string Password { get; set; }
        public static string ChangedName { get; set; }
        public static string ChangedEmail { get; set; }
        public static string ChangedCpf { get; set; }
        public static string ChangedPassword { get; set; }

        public List<UserDtoResult> listUserDtoResult = new List<UserDtoResult>();
        public UserDto userDto = new UserDto();
        public UserDto userDtoUpdate = new UserDto();
        public UserDtoResult userDtoResult = new UserDtoResult();
        public UserDtoResult userDtoResultUpdate = new UserDtoResult();

        public UserTest()
        {
            const string VALID_CPF = "12345678909";
            const string VALID_CPF_UPDATE = "51955314047";
            const string VALID_PASSWORD = "teste123";
            const string VALID_PASSWORD_UPDATE = "teste321";

            Id = Guid.NewGuid();
            Name = Faker.Name.FullName();
            Email = Faker.Internet.Email();
            Cpf = VALID_CPF;
            Password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            ChangedName = Faker.Name.FullName();
            ChangedEmail = Faker.Internet.Email();
            ChangedCpf = VALID_CPF_UPDATE;
            ChangedPassword = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD_UPDATE, BCrypt.Net.BCrypt.GenerateSalt());

            for (int i = 0; i < 5; i++)
            {
                var dto = new UserDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    Cpf = Cpf
                };

                listUserDtoResult.Add(dto);
            }

            userDto = new UserDto()
            {
                Name = Name,
                Email = Email,
                Cpf = Cpf,
                Password = Password
            };

            userDtoUpdate = new UserDto()
            {
                Name = ChangedName,
                Email = ChangedEmail,
                Cpf = ChangedCpf,
                Password = ChangedPassword
            };

            userDtoResult = new UserDtoResult()
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Cpf = Cpf
            };

            userDtoResultUpdate = new UserDtoResult()
            {
                Id = Id,
                Name = ChangedName,
                Email = ChangedEmail,
                Cpf = ChangedCpf
            };
        }
    }
}
