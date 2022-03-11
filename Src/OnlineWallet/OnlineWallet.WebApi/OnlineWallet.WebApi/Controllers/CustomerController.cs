using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlakeyBit.DigestAuthentication.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        /// create new customer
        /// </summary>
        /// <param name="model">login and password</param>
        /// <response code="200"></response>
        /// <response code="500">Error</response>
        [HttpPost(nameof(AddCustomer))]
        public async Task AddCustomer(CreateCustomerModel model)
        {
            await _customerService.CreateCustomer(model);
        }
    }
}
