using OnlineWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Dal;
using OnlineWallet.Dal.Transaction;

namespace OnlineWallet.Impl
{
    internal class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;

        public TransactionService(ITransactionRepository transactionRepository, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
        }

        public async Task AddTransaction(SendTransactionModel model)
        {
            var transaction = new MoneyTransaction()
            {
                AddMoney = model.AddMoney,
                Sum = model.Sum,
                WalletId = model.WalletId,
                Date = DateTime.UtcNow,
            };
            await _walletRepository.DoTransaction(transaction);
            await _transactionRepository.AddAsync(transaction);
        }
    }
}
