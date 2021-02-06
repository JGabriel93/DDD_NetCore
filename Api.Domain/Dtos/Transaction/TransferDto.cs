using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Transaction
{
    public class TransferDto
    {
        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(1, 10000000, ErrorMessage = "O valor deve ter no mínimo {1} e no máximo {2}")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "CPF do destinatário é obrigatório")]
        public string CpfRecipient { get; set; }
    }
}
