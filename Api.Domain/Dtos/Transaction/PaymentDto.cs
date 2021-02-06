using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Transaction
{
    public class PaymentDto
    {
        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(1, 10000000, ErrorMessage = "O valor deve ser no mínimo {1} e no máximo {2}")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Código de barras é obrigatório")]
        [StringLength(47, MinimumLength = 44, ErrorMessage = "O código de barras deve entre {2} e {1} dígitos")]
        public string BarCode { get; set; }
    }
}
