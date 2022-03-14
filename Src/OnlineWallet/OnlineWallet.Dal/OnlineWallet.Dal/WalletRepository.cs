using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineWallet.Models;

namespace OnlineWallet.Dal
{
    internal class WalletRepository : RepositoryBase<WalletContext, DbWallet, Wallet>, IWalletRepository
    {
        private readonly WalletOptions _config;

        public WalletRepository(WalletContext context, IMapper mapper, IOptions<WalletOptions> options) : base(context,
            mapper)
        {
            _config = options.Value;
        }

        public async Task ApplyTransactionAsync(MoneyTransaction moneyTransaction)
        {
            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                var wallet = await base.Query()
                    .Where(x => moneyTransaction.WalletId == x.Id)
                    .Include(x => x.Customer)
                    .FirstOrDefaultAsync();

                if (wallet == null)
                {
                    throw new ServiceException("Wallet does not exist");
                }

                if (moneyTransaction.AddMoney && (wallet.Customer.PassAllAuthorization
                                                  && wallet.Balance + moneyTransaction.Sum >
                                                  _config.MaxSumForFullAuthorizedCustomer
                                                  || !wallet.Customer.PassAllAuthorization
                                                  && wallet.Balance + moneyTransaction.Sum >
                                                  _config.MaxSumForNoFullAuthorizedCustomer))
                {
                    throw new ServiceException("Wallet limit exceeded");
                }

                if (!moneyTransaction.AddMoney && wallet.Balance - moneyTransaction.Sum < 0)
                {
                    throw new ServiceException("Insufficient funds");
                }

                wallet.Balance = moneyTransaction.AddMoney
                    ? wallet.Balance + moneyTransaction.Sum
                    : wallet.Balance - moneyTransaction.Sum;
                await Context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }

        public async Task<int> GetWalletBalanceAsync(Guid userId)
        {
            return await base.Query()
                .Where(x => x.CustomerId == userId)
                .Select(x => x.Balance)
                .FirstOrDefaultAsync();
        }
    }
}
