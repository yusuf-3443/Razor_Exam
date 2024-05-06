using Domain.DTOs.CustomerDTOs; // Changed from TransactionDTOs
using Infrastructure.Services.CustomerService; // Changed from TransactionService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorApp.Pages.Customer // Changed from Transaction
{
    [IgnoreAntiforgeryToken]
    public class CreateCustomerModel : PageModel // Changed from CreateTransactionModel
    {
        private readonly ICustomerService _customerService; // Changed from ITransactionService

        public CreateCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService; // Changed from _transactionService
        }

        [BindProperty]
        public AddCustomerDto CustomerDto { get; set; } // Changed from TransactionDto

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.CreateCustomerAsync(CustomerDto); // Changed from CreateTransactionAsync

            return RedirectToPage("/Customer/GetCustomers"); // Changed from Transaction/GetTransactions
        }
    }
}
