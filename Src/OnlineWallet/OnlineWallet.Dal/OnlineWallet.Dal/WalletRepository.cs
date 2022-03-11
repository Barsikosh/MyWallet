using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineWallet.Models;

namespace OnlineWallet.Dal
{
    internal class WalletRepository : RepositoryBase<WalletContext, DbWallet, Wallet>, IWalletRepository
    {
        public WalletRepository(WalletContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task DoTransaction(MoneyTransaction transaction)
        {
            await base.Query()
                .Where(x => x.Id == transaction.WalletId)
                .UpdateFromQueryAsync(x => new DbWallet
                {
                    Id = x.Id,
                    Balance = transaction.AddMoney? x.Balance + transaction.Sum : x.Balance - transaction.Sum,
                    CustomerId = x.CustomerId
                });
        }

        public async Task<Wallet> FindByUserId(Guid userId)
        {
            return await base.Query()
                .Where(x => x.CustomerId == userId)
                .Select(x => Mapper.Map<Wallet>(x))
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetWalletBalance(Guid userId)
        {
            return await base.Query()
                .Where(x => x.CustomerId == userId)
                .Select(x => x.Balance)
                .FirstOrDefaultAsync();
        }
    }
}
