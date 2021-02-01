namespace Api.Domain.Entities.User
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
