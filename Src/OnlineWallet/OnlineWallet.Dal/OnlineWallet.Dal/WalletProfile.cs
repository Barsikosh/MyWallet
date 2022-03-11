using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
