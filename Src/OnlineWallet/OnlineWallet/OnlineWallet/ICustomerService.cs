using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet
{
    public interface ICustomerService
    {
        public Task CreateCustomer(CreateCustomerModel model);

        public Task<Customer> GetUserByPassword(string userName);
    }
}
