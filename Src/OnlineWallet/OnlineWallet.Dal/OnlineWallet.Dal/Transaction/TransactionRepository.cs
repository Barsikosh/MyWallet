using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineWallet.Dal.Entities;
using OnlineWallet.Models;

namespace OnlineWallet.Dal.Transaction
{
    internal class TransactionRepository : RepositoryBase<WalletContext, DbTransaction, MoneyTransaction>, ITransactionRepository
    {
        public TransactionRepository(WalletContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<OperationResultModel> GetAllTransactionsAddForMonthAsync(Guid userId, DateTime currentDateTime)
        {
            var transactions = await base.Query()
                .Where(x => x.Wallet.CustomerId == userId && x.AddMoney && ((((currentDateTime.Date.Year - x.Date.Year) * 12) + currentDateTime.Month - x.Date.Month) <= 1))
                .OrderByDescending(x => x.Date)
                .ToArrayAsync();
            return new OperationResultModel()
            {
                AllSum = transactions.Select(x => x.Sum).ToArray(),
                AllAddMoneyTransactionCount = transactions.Length,
            };
        }
    }
}
