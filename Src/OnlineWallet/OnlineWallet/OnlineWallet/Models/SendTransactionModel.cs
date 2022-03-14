using System;

namespace OnlineWallet.Models
{
    public class SendTransactionModel
    {
        public int Sum { get; set; }

        public bool AddMoney { get; set; }

        public Guid WalletId { get; set; }
    }
}
