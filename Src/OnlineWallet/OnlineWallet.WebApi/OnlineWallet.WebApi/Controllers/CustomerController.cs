using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineWallet.Models;

namespace OnlineWallet.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// check wallet
        /// </summary>
        /// <returns>bool</returns>
        /// <response code="200">bool</response>
        /// <response code="500">Error</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpGet(nameof(CheckIfUserExists))]
        public async Task<bool> CheckIfUserExists(Guid userId)
        {
            return await _customerService.CheckIfUserExistsAsync(userId);
        }

        /// <summary>
        /// create new customer
        /// </summary>
        /// <param name="model">login and password</param>
        /// <response code="200"></response>
        /// <response code="500">Error</response>
        [HttpPost(nameof(AddCustomer))]
        public async Task AddCustomer(CreateCustomerModel model)
        {
            await _customerService.CreateCustomerAsync(model);
        }
    }
}
