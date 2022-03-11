using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet.Dal
{
    public interface  IWalletRepository : IRepository<Wallet>
    {
        public Task<int> GetWalletBalance(Guid walletId);

        public Task<Wallet> FindByUserId(Guid userId);

        public Task DoTransaction(MoneyTransaction transaction);
    }
}
