using Domain.DTOs.CustomerDTOs; // Changed from AccountDTOs
using Infrastructure.Services.CustomerService; // Changed from AccountService
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorApp.Pages.Customer // Changed from Account
{
    public class UpdateCustomerModel : PageModel // Changed from UpdateAccountModel
    {
        private readonly ICustomerService _customerService; // Changed from IAccountService

        public UpdateCustomerModel(ICustomerService customerService) // Changed from IAccountService
        {
            _customerService = customerService; // Changed from _accountService
        }

        [BindProperty]
        public UpdateCustomerDto Customer { get; set; } // Changed from UpdateAccountDto

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Customer.Id = id; // Changed from Account to Customer
            await _customerService.UpdateCustomerAsync(Customer); // Changed from _accountService

            return RedirectToPage("/Customer/GetCustomers"); // Changed from Account to Customer
        }
    }
}
