using Infrastructure.Services.TransactionService; // Changed from ProductService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Transaction // Changed from Product
{
    public class DeleteTransactionModel : PageModel // Changed from DeleteProductModel
    {
        private readonly ITransactionService _transactionService; // Changed from IProductService

        public DeleteTransactionModel(ITransactionService transactionService) // Changed from DeleteProductModel
        {
            _transactionService = transactionService; // Changed from _ProductService
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _transactionService.RemoveTransactionAsync(Id); // Changed from _ProductService
            return RedirectToPage("/Transaction/GetTransactions"); // Changed from Product/GetProducts
        }
    }
}
