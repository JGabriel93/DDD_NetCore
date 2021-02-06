using System;

namespace Api.Domain.Models.CurrentAccount
{
    public class CurrentAccountModel : BaseModel
    {
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private Guid _userId;
        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
