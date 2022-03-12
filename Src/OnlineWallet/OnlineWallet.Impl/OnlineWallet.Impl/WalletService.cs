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

        public async Task<bool> CheckIfWalletExists(Guid userId)
        {
            var wallets = await _walletRepository.FindByUserId(userId);
            return wallets != null;
        }

        public async Task<OperationResultModel> GetOperationForMonth(Guid userId)
        {
            var result = await _transactionRepository.GetAllTransactionForMonth(userId, DateTime.UtcNow);
            return result;
        }

        public async Task<int> GetWalletBalance(Guid userId)
        {
            return await _walletRepository.GetWalletBalance(userId);
        }
    }
}
