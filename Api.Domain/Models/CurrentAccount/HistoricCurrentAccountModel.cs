using System;

namespace Api.Domain.Models.CurrentAccount
{
    public class HistoricCurrentAccountModel : BaseModel
    {
        private string _movement;
        public string Movement
        {
            get { return _movement; }
            set { _movement = value; }
        }

        private decimal _amountMoved;
        public decimal AmountMoved
        {
            get { return _amountMoved; }
            set { _amountMoved = value; }
        }

        private Guid _currentAccountId;
        public Guid CurrentAccountId
        {
            get { return _currentAccountId; }
            set { _currentAccountId = value; }
        }
    }
}
