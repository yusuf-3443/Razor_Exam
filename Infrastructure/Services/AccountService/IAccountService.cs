using Domain.DTOs.AccountDTOs;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.AccountService
{
    public interface IAccountService
    {
        Task<PagedResponse<List<GetAccountDto>>> GetAccountsAsync(AccountFilter filter);
        Task<Response<GetAccountDto>> GetAccountByIdAsync(int accountId);
        Task<Response<string>> CreateAccountAsync(AddAccountDto account);
        Task<Response<string>> UpdateAccountAsync(UpdateAccountDto account);
        Task<Response<bool>> RemoveAccountAsync(int accountId);
    }
}
