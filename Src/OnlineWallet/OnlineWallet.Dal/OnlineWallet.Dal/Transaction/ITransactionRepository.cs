using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet.Dal.Transaction
{
    public interface ITransactionRepository : IRepository<MoneyTransaction>
    {
        public Task<OperationResultModel> GetAllTransactionsAddForMonthAsync(Guid walletId, DateTime currentDateTime);
    }
}
