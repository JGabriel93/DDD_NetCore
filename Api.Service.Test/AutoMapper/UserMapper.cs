using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities.User;
using Api.Domain.Models.User;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTest
    {
        [Fact(DisplayName = "Mantida a integridade dos mapeamentos de usuário")]
        public void TestMapper()
        {
            const string VALID_CPF = "12345678909";
            const string VALID_PASSWORD = "teste123";

            var password = BCrypt.Net.BCrypt.HashPassword(VALID_PASSWORD, BCrypt.Net.BCrypt.GenerateSalt());

            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Cpf = VALID_CPF,
                Password = password
            };

            var listEntity = new List<UserEntity>();
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

                listEntity.Add(user);
            }

            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.Cpf, model.Cpf);
            Assert.Equal(entity.Password, model.Password);

            var dto = Mapper.Map<UserDto>(entity);
            Assert.Equal(dto.Name, entity.Name);
            Assert.Equal(dto.Email, entity.Email);
            Assert.Equal(dto.Cpf, entity.Cpf);
            Assert.Equal(dto.Password, entity.Password);

            var listEntityToListDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listEntityToListDto.Count() == listEntity.Count());
            for (int i = 0; i < listEntityToListDto.Count(); i++)
            {
                Assert.Equal(listEntityToListDto[i].Name, listEntity[i].Name);
                Assert.Equal(listEntityToListDto[i].Email, listEntity[i].Email);
                Assert.Equal(listEntityToListDto[i].Cpf, listEntity[i].Cpf);
                Assert.Equal(listEntityToListDto[i].Password, listEntity[i].Password);
            }

            var userDtoResult = Mapper.Map<UserDtoResult>(entity);
            Assert.Equal(userDtoResult.Name, entity.Name);
            Assert.Equal(userDtoResult.Email, entity.Email);
            Assert.Equal(userDtoResult.Cpf, entity.Cpf);

            var dtoToModel = Mapper.Map<UserModel>(dto);
            Assert.Equal(dtoToModel.Name, dto.Name);
            Assert.Equal(dtoToModel.Email, dto.Email);
            Assert.Equal(dtoToModel.Cpf, dto.Cpf);
            Assert.Equal(dtoToModel.Password, dto.Password);
        }
    }
}
