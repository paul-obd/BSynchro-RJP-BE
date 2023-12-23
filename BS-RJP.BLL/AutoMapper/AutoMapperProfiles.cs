using AutoMapper;
using BS_RJP.EF.Models;
using RJP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_RJP.BLL.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, TblUser>()
                         .ForMember(x => x.TblCustomers, opt => opt.MapFrom(z => z.Customers))
                         .ForMember(x => x.TblAccounts, opt => opt.MapFrom(z => z.Accounts))
                         .ForMember(x => x.TblTransactions, opt => opt.MapFrom(z => z.Transactions))
                         .ForMember(x => x.TblTransactionTypes, opt => opt.MapFrom(z => z.TransactionTypes))
                         .ReverseMap();

            CreateMap<Account, TblAccount>()
                .ForMember(x => x.TblTransactions, opt => opt.MapFrom(z => z.Transactions))
                 .ReverseMap();

            CreateMap<Customer, TblCustomer>()
                 .ForMember(x => x.TblAccounts, opt => opt.MapFrom(z => z.Accounts))
                 .ReverseMap();

            CreateMap<TransactionType, TblTransactionType>()
                 .ForMember(x => x.TblTransactions, opt => opt.MapFrom(z => z.Transactions))
                 .ReverseMap();

            CreateMap<Transaction, TblTransaction>()
                .ReverseMap();
        }
      
    }
}
