using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
