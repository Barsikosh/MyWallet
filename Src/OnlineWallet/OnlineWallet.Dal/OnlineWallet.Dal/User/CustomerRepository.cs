
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineWallet.Dal.Entities;
using OnlineWallet.Models;

namespace OnlineWallet.Dal.User
{
    internal class CustomerRepository : RepositoryBase<WalletContext, DbCustomer, Customer>, ICustomerRepository
    {
        public CustomerRepository(WalletContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Customer> GetCustomerByNameAsync(string userName)
        {
            return await Query()
                .Where(x => userName == x.UserName)
                .Select(x => Mapper.Map<Customer>(x))
                .FirstOrDefaultAsync();
        }
    }
}
