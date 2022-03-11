using OnlineWallet.Models;
using System;
using System.Threading.Tasks;
using OnlineWallet.Dal;
using OnlineWallet.Dal.Transaction;

namespace OnlineWallet.Impl
{
    internal class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ITransactionRepository _transactionRepository;

        public WalletService(IWalletRepository walletRepository, ITransactionRepository transactionRepository)
        {
            _walletRepository = walletRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<bool> CheckIfWalletExists(Guid? userId)
        {
            if (!userId.HasValue)
            {
                return false;
            }
            var wallets = await _walletRepository.FindByUserId(userId.Value);
            return wallets != null;
        }

        public async Task<OperationResultModel> GetOperationForMonth(Guid? userId)
        {
            if (!userId.HasValue)
            {
                return new OperationResultModel();
            }
            var result = await _transactionRepository.GetAllTransactionForMonth(userId.Value, DateTime.UtcNow);
            return result;
        }

        public async Task<int> GetWalletBalance(Guid? userId)
        {
            if (!userId.HasValue)
            {
                return 0;
            }
            return await _walletRepository.GetWalletBalance(userId.Value);
        }

    }
}
