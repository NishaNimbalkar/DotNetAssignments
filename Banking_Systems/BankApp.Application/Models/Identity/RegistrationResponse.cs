﻿namespace BankApp.Application.Models.Identity
{
    public class RegistrationResponse
    {
      public string UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
