using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Domain
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        = string.Empty;
    }
}
