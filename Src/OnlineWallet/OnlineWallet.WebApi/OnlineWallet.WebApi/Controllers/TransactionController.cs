using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineWallet.Models;

namespace OnlineWallet.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// send transaction
        /// </summary>
        /// <param name="transaction">transaction</param>
        /// <response code="200"></response>
        /// <response code="500">Error</response>
        [HttpPost(nameof(SendTransaction))]
        public async Task SendTransaction(SendTransactionModel transaction)
        {
            await _transactionService.AddTransactionAsync(transaction);
        }
    }
}
