using System;
using System.Collections.Generic;
using Api.Domain.Entities.User;

namespace Api.Domain.Entities.CurrentAccount
{
    public class CurrentAccountEntity : BaseEntity
    {
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
        public IEnumerable<HistoricCurrentAccountEntity> Historic { get; set; }
    }
}
