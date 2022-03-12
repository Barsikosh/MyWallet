using OnlineWallet.Models;
using System;
using System.Net;
using System.Net.Http;
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

        public async Task<OperationResultModel> GetAddTransactionsForMonthAsync(Guid userId)
        {
            var result = await _transactionRepository.GetAllTransactionsAddForMonthAsync(userId, DateTime.UtcNow);
            return result;
        }

        public async Task<int> GetWalletBalanceAsync(Guid userId)
        {
            return await _walletRepository.GetWalletBalanceAsync(userId);
        }
    }
}
