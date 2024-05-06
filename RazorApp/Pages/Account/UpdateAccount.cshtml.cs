using Domain.DTOs.AccountDTOs; // Changed from MarketDTOs
using Infrastructure.Services.AccountService; // Changed from MarketService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Account // Changed from Market
{
    public class UpdateAccountModel : PageModel
    {
        private readonly IAccountService _accountService; // Changed from IMarketService

        public UpdateAccountModel(IAccountService accountService) // Changed from IMarketService
        {
            _accountService = accountService; // Changed from _MarketService
        }

        [BindProperty]
        public UpdateAccountDto Account { get; set; } // Changed from UpdateMarketDto

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            Account.Id = id; // Changed from Market to Account
            await _accountService.UpdateAccountAsync(Account); // Changed from _MarketService

            return RedirectToPage("/Account/GetAccounts"); // Changed from Market to Account
        }
    }
}
