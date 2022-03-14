using System;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet.Dal.Transaction
{
    public interface ITransactionRepository : IRepository<MoneyTransaction>
    {
        public Task<OperationResultModel> GetAllReplenishmentTransactionsForMonthAsync(Guid walletId, DateTime currentDateTime);
    }
}
