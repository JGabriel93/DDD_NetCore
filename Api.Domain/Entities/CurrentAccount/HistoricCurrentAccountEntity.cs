using System;

namespace Api.Domain.Entities.CurrentAccount
{
    public class HistoricCurrentAccountEntity : BaseEntity
    {
        public string Movement { get; set; }
        public decimal AmountMoved { get; set; }
        public Guid CurrentAccountId { get; set; }

        public virtual CurrentAccountEntity CurrentAccount { get; set; }
    }
}
