using System;

namespace Api.Domain.Dtos.CurrentAccount
{
    public class HistoricCurrentAccountDtoResult
    {
        public Guid Id { get; set; }
        public string Movement { get; set; }
        public decimal AmountMoved { get; set; }
        public string CreateAt { get; set; }
        public Guid CurrentAccountId { get; set; }

        public CurrentAccountDtoResult CurrentAccount { get; set; }
    }
}
