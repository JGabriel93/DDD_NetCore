using Api.Domain.Entities.CurrentAccount;

namespace Api.Domain.Entities.User
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public CurrentAccountEntity CurrentAccount { get; set; }
    }
}
