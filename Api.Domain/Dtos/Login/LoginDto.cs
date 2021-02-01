using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}
