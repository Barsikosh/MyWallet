using System;

namespace OnlineWallet.Models
{
    public class MoneyTransaction : IModelWithId
    {
        public Guid? Id { get; set; }

        public int Sum { get; set; }

        public bool AddMoney { get; set; }

        public Guid WalletId { get; set; }

        public DateTime Date { get; set; }
    }
}
