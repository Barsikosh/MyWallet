using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineWallet.Models
{
    public interface IMonetaryTransaction
    {
        public int Sum { get; set; }

        public bool AddMoney { get; set; }
    }
}
