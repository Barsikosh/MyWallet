using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Dal.loC;

namespace OnlineWallet.Impl.loC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection WithImplServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .WithDalCollection()
                .AddScoped<IWalletService, WalletService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ITransactionService, TransactionService>()

                ;
            return serviceCollection;
        }
    }
}
