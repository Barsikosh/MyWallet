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
        public Task<int> GetWalletBalance(Guid? userId);

        public Task<bool> CheckIfWalletExists(Guid? userId);

        public Task<OperationResultModel> GetOperationForMonth(Guid? userId);
    }
}
