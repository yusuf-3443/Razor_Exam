using Domain.DTOs.AccountDTOs;
using Domain.DTOs.CustomerDTOs; // Changed from TransactionDTOs
using Infrastructure.Services.AccountService;
using Infrastructure.Services.CustomerService; // Changed from TransactionService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorApp.Pages.Account // Changed from Transaction
{
    [IgnoreAntiforgeryToken]
    public class CreateAccountModel : PageModel // Changed from CreateTransactionModel
    {
        private readonly IAccountService _accountService; // Changed from ITransactionService

        public CreateAccountModel(IAccountService accountService)
        {
            _accountService = accountService; // Changed from _transactionService
        }

        [BindProperty]
        public AddAccountDto AccountDto { get; set; } // Changed from TransactionDto

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _accountService.CreateAccountAsync(AccountDto); // Changed from CreateTransactionAsync

            return RedirectToPage("/Account/GetAccounts"); // Changed from Transaction/GetTransactions
        }
    }
}
