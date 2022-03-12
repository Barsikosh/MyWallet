using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet
{
    public interface IWalletService
    {
        public Task<int> GetWalletBalanceAsync(Guid userId);

        public Task<OperationResultModel> GetAddTransactionsForMonthAsync(Guid userId);
    }
}
