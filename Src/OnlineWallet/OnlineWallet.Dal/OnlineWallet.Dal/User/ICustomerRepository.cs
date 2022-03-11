using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet.Dal.User
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Task<Customer> GetCustomerByName(string userName);
    }
}
