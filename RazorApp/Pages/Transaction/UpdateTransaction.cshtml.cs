using Domain.DTOs.TransactionDTOs; // Changed from CustomerDTOs
using Infrastructure.Services.TransactionService; // Changed from CustomerService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorApp.Pages.Transaction // Changed from Customer
{
    public class UpdateTransactionModel : PageModel // Changed from UpdateCustomerModel
    {
        private readonly ITransactionService _transactionService; // Changed from ICustomerService

        public UpdateTransactionModel(ITransactionService transactionService)
        {
            _transactionService = transactionService; // Changed from _customerService
        }

        [BindProperty]
        public UpdateTransactionDto Transaction { get; set; } // Changed from Customer

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Transaction.Id = id; 
            await _transactionService.UpdateTransactionAsync(Transaction);

            return RedirectToPage("/Transaction/GetTransactions"); // Changed from Customer/GetCustomers
        }
    }
}
