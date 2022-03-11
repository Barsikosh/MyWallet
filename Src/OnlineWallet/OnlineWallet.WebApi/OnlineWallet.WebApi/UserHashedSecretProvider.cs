using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlakeyBit.DigestAuthentication.Implementation;
using Microsoft.AspNetCore.Http;
using OnlineWallet.Impl;

namespace OnlineWallet.WebApi
{
    internal class UserHashedSecretProvider : IUsernameHashedSecretProvider
    {
        private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserHashedSecretProvider(ICustomerService customerService, IHttpContextAccessor httpContextAccessor)
        {
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetA1Md5HashForUsernameAsync(string username, string realm)
        {
            var user = await _customerService.GetUserByPassword(username);
            _httpContextAccessor.HttpContext.Response.Headers[Constants.UserIdHeader] = user.Id.GetValueOrDefault().ToString();
            _httpContextAccessor.HttpContext.Request.Headers[Constants.UserIdHeader] = user.Id.GetValueOrDefault().ToString();
            return user.HashPassword;
        }
    }
}
