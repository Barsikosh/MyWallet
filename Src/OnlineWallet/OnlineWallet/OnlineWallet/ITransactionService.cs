using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet
{
    public interface ITransactionService
    {
        public Task AddTransaction(SendTransactionModel model);
    }
}
