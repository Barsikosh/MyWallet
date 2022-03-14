using System;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet.Dal
{
    public interface  IWalletRepository : IRepository<Wallet>
    {
        public Task<int> GetWalletBalanceAsync(Guid walletId);

        public Task ApplyTransactionAsync(MoneyTransaction transaction);
    }
}
