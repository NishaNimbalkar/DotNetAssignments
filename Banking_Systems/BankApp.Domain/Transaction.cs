using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BankApp.Domain.Enum;

namespace BankApp.Domain
{
    public class Transaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]

        [JsonIgnore]
        public Account Account { get; set; } 
        [Required]
        public TransactionType Type {  get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Description {  get; set; }

    }
}
