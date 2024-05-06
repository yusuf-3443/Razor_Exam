using Domain.DTOs.TransactionDTOs; // Changed from AccountDTOs
using Infrastructure.Services.TransactionService; // Changed from AccountService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorApp.Pages.Transaction // Changed from Account
{
    [IgnoreAntiforgeryToken]
    public class CreateTransactionModel : PageModel // Changed from CreateAccountModel
    {
        private readonly ITransactionService _transactionService; // Changed from IAccountService

        public CreateTransactionModel(ITransactionService transactionService)
        {
            _transactionService = transactionService; // Changed from _accountService
        }

        [BindProperty]
        public AddTransactionDto TransactionDto { get; set; } // Changed from AccountDto

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _transactionService.CreateTransactionAsync(TransactionDto); // Changed from CreateAccountAsync

            return RedirectToPage("/Transaction/GetTransactions"); // Changed from Account/GetAccounts
        }
    }
}
