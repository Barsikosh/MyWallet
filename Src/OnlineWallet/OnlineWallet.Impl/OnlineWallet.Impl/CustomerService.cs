using OnlineWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FlakeyBit.DigestAuthentication.Implementation;
using OnlineWallet.Dal.User;

namespace OnlineWallet.Impl
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CheckIfUserExistsAsync(Guid userId)
        {
            var exist = await _customerRepository.FindAsync(userId);
            return exist != null;
        }

        public async Task CreateCustomerAsync(CreateCustomerModel model)
        {
            var hashPassword = DigestAuthentication.ComputeA1Md5Hash(model.UserName, Constants.Realm, model.Password);
            await _customerRepository.AddAsync(new Customer()
            {
                UserName = model.UserName,
                HashPassword = hashPassword,
                PassAllAuthorization = model.PassAllAuthorization,
                
            });
        }

        public async Task<Customer> GetUserByUserName(string userName)
        {
            return await _customerRepository.GetCustomerByNameAsync(userName);
        }
    }
}
