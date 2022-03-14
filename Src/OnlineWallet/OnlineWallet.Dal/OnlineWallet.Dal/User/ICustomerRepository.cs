using System.Threading.Tasks;
using OnlineWallet.Models;

namespace OnlineWallet.Dal.User
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Task<Customer> GetCustomerByNameAsync(string userName);
    }
}
