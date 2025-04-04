using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Enum;

namespace BankApp.Application.Models.Accounts
{
    public sealed record class AddAccountRequest
    {

        public int AccountId { get; set; }
        //public string UserId { get; set; }

        public string AccountNumber { get; set; }


        public double Balance { get; set; }


        public AccountType AccountType { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
