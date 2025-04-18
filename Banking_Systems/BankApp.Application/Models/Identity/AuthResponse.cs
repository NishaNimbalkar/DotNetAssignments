﻿namespace BankApp.Application.Models.Identity
{
    public class AuthResponse      //whenever you pass the request generate token
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; }=string.Empty;
        public string Token {  get; set; } = string.Empty;
    }
}
