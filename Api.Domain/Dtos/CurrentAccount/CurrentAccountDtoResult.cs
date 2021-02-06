using System;
using Api.Domain.Dtos.User;

namespace Api.Domain.Dtos.CurrentAccount
{
    public class CurrentAccountDtoResult
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Guid UserId { get; set; }

        public UserDtoResult User { get; set; }
    }
}
