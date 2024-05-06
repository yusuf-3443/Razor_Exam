using System.Net;
using Domain.DTOs.TransactionDTOs; // Changed from CustomerDTOs
using Domain.Filters;
using Infrastructure.Services.TransactionService; // Changed from CustomerService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorApp.Pages.Transaction // Changed from Customer
{
    [IgnoreAntiforgeryToken]
    public class GetTransactionsModel : PageModel // Changed from GetCustomersModel
    {
        private readonly ITransactionService _transactionService; // Changed from ICustomerService

        public GetTransactionsModel(ITransactionService transactionService)
        {
            _transactionService = transactionService; // Changed from _customerService
            Transactions = new List<GetTransactionDto>();
        }

        [BindProperty(SupportsGet = true)]
        public TransactionFilter Filter { get; set; } // Changed from CustomerFilter
        public int TotalPages { get; set; }

        public List<GetTransactionDto> Transactions { get; set; } // Changed from Customers

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var response = await _transactionService.GetTransactionsAsync(Filter); // Changed from GetCustomersAsync
                Transactions = response.Data; // Changed from Customers
                TotalPages = response.TotalPages;
                return Page();
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
