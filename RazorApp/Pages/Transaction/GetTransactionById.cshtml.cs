using System.Threading.Tasks;
using Domain.DTOs.TransactionDTOs; // Changed from ProductDTOs
using Infrastructure.Services.TransactionService; // Changed from ProductService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Transaction // Changed from Product
{
    public class GetTransactionByIdModel : PageModel // Changed from GetProductByIdModel
    {
        private readonly ITransactionService _transactionService; // Changed from IProductService

        public GetTransactionByIdModel(ITransactionService transactionService) // Changed from GetProductByIdModel
        {
            _transactionService = transactionService; // Changed from _ProductService
        }

        public GetTransactionDto Transaction { get; set; } // Changed from GetProductDto

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id); // Changed from _ProductService
            Transaction = transaction.Data;
            if (Transaction == null)
            {
                return NotFound(); 
            }

            return Page();
        }
    }
}
