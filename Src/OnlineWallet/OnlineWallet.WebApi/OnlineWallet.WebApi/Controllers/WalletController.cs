using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineWallet.Impl;

namespace OnlineWallet.WebApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Digest")]
    [Route("/api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly ICustomerService _customerService;

        public WalletController(IWalletService walletService, ICustomerService customerService)
        {
            _walletService = walletService;
            _customerService = customerService;
        }

        /// <summary>
        /// get wallet balance
        /// </summary>
        /// <returns>balance</returns>
        /// <response code="200">Balance</response>
        /// <response code="500">Error</response>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [HttpGet(nameof(CheckBalance))]
        public async Task<int> CheckBalance()
        {
            return await _walletService.GetWalletBalanceAsync(await GetUserId());
        }

        /// <summary>
        /// get replenishment transactions for a month
        /// </summary>
        /// <returns>bool</returns>
        /// <response code="200">r</response>
        /// <response code="500">Error</response>
        [ProducesResponseType(typeof(OperationResultModel), StatusCodes.Status200OK)]
        [HttpGet(nameof(GetReplenishmentTransactionsForMonth))]
        public async Task<OperationResultModel> GetReplenishmentTransactionsForMonth()
        {
            return await _walletService.GetReplenishmentTransactionsForMonthAsync(await GetUserId());
        }

        private async Task<Guid> GetUserId()
        {
            var userName = User.FindFirstValue(Constants.ClaimType);
            return (await _customerService.GetUserByUserName(userName)).Id!.Value;
        }
    }
}
