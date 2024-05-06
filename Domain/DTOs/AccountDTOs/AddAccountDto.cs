using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs.AccountDTOs
{
    public class AddAccountDto
    {
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public int OwnerId { get; set; }
    public string Type { get; set; }
    }
}