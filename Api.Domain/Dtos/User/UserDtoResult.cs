using System;

namespace Api.Domain.Dtos.User
{
    public class UserDtoResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
