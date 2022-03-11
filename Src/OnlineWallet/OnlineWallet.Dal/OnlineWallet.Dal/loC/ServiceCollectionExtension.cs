using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWallet.Dal.Transaction;
using OnlineWallet.Dal.User;

namespace OnlineWallet.Dal.loC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection WithDalCollection(this IServiceCollection serviceCollection)
        {
            return 
                serviceCollection
                    .AddTransient<WalletContext>()
                    .AddScoped<IWalletRepository, WalletRepository>()
                    .AddScoped<ITransactionRepository, TransactionRepository>()
                    .AddScoped<ICustomerRepository, CustomerRepository>()
                    .AddAutoMapper(typeof(WalletProfile));
        }
    }
}
