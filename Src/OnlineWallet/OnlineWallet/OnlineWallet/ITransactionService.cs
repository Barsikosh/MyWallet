using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet
{
    public interface ITransactionService
    {
        public Task AddTransactionAsync(SendTransactionModel model);
    }
}
