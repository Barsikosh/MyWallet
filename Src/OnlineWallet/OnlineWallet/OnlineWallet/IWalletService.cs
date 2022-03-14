using System;
using System.Threading.Tasks;

namespace OnlineWallet
{
    public interface IWalletService
    {
        public Task<int> GetWalletBalanceAsync(Guid userId);

        public Task<OperationResultModel> GetReplenishmentTransactionsForMonthAsync(Guid userId);
    }
}
