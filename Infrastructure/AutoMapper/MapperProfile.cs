using System.Runtime.InteropServices;
using AutoMapper;
using Domain.DTOs.AccountDTOs;
using Domain.DTOs.CustomerDTOs;
using Domain.DTOs.TransactionDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Account, GetAccountDto>().ReverseMap();
        CreateMap<Account, AddAccountDto>().ReverseMap();
        CreateMap<Account, UpdateAccountDto>().ReverseMap();

        CreateMap<Customer, GetCustomerDto>().ReverseMap();
        CreateMap<Customer, AddCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

        CreateMap<Transaction, GetTransactionDto>().ReverseMap();
        CreateMap<Transaction, AddTransactionDto>().ReverseMap();
        CreateMap<Transaction, UpdateTransactionDto>().ReverseMap();
    }
}