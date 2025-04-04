using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.Models.Transactions
{
    public class TransactionTransfer
    {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public double Amount { get; set; }

    }
}
