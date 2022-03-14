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

        public async Task<OperationResultModel> GetReplenishmentTransactionsForMonthAsync(Guid userId)
        {
            return await _transactionRepository.GetAllReplenishmentTransactionsForMonthAsync(userId, DateTime.UtcNow);
        }

        public async Task<int> GetWalletBalanceAsync(Guid userId)
        {
            return await _walletRepository.GetWalletBalanceAsync(userId);
        }
    }
}
