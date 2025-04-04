using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Models.Identity;
using BankApp.Domain;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Infrastrucure.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<JwtSecurityToken> GenerateToken(ApplicationUser user);
    }
}
