using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BankApp.Domain.Enum;

namespace BankApp.Domain
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]

        //[JsonIgnore]
        public ApplicationUser User { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        ///public ICollection<Transaction> Transactions { get; set; } 
    }
}
