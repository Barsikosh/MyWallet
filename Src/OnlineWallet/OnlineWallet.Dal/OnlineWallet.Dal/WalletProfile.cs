using AutoMapper;
using OnlineWallet.Dal.Entities;
using OnlineWallet.Models;

namespace OnlineWallet.Dal
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<DbTransaction, MoneyTransaction>()
                .ReverseMap();
            CreateMap<DbCustomer, Customer>()
                .ReverseMap();
            CreateMap<DbWallet, Wallet>()
                .ReverseMap();
        }
    }
}
