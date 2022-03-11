using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineWallet.Models;

namespace OnlineWallet.WebApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Digest")]
    [Route("/api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        /// <summary>
        /// method to get wallet balance
        /// </summary>
        /// <returns>balance</returns>
        /// <response code="200">Balance</response>
        /// <response code="500">Error</response>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [HttpGet(nameof(CheckBalance))]
        public async Task<int> CheckBalance()
        {
            return await _walletService.GetWalletBalance(GetUserId());
        }

        /// <summary>
        /// method to check wallet
        /// </summary>
        /// <returns>bool</returns>
        /// <response code="200">bool</response>
        /// <response code="500">Error</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpGet(nameof(CheckIfWalletExists))]
        public async Task<bool> CheckIfWalletExists()
        {
            return await _walletService.CheckIfWalletExists(GetUserId());
        }

        /// <summary>
        /// method to get transactions for a month
        /// </summary>
        /// <returns>bool</returns>
        /// <response code="200">bool</response>
        /// <response code="500">Error</response>
        [ProducesResponseType(typeof(OperationResultModel), StatusCodes.Status200OK)]
        [HttpGet(nameof(GetAllTransactionForMonth))]
        public async Task<OperationResultModel> GetAllTransactionForMonth()
        {
            return await _walletService.GetOperationForMonth(GetUserId());
        }

        private Guid? GetUserId()
        {
            var userId = HttpContext.Request.Headers[Constants.UserIdHeader].FirstOrDefault();
            return userId == null ? null : Guid.Parse(userId);
        }
    }
}
