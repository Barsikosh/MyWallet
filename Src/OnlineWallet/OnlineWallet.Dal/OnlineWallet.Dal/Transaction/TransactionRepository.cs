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

        public async Task<OperationResultModel> GetAllTransactionForMonth(Guid userId, DateTime currentDateTime)
        {
            var da = base.Query()
                .Select(x =>
                    Math.Abs(((currentDateTime.Date.Year - x.Date.Year) * 12) + currentDateTime.Month - x.Date.Month))
                .ToArray();
            var transactions = await base.Query()
                .Where(x => x.Wallet.CustomerId == userId && (Math.Abs(((currentDateTime.Date.Year - x.Date.Year) * 12) + currentDateTime.Month - x.Date.Month) <= 1)
                )
                .ToArrayAsync();
            return new OperationResultModel()
            {
                AllSum = transactions.Select(x => x.Sum).ToArray(),
                AllAddMoneyTransactionCount = transactions.Length,
            };
        }
    }
}
