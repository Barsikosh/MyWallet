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
        public Task CreateCustomerAsync(CreateCustomerModel model);

        public Task<Customer> GetUserByUserName(string userName);

        public Task<bool> CheckIfUserExistsAsync(Guid userId);
    }
}
