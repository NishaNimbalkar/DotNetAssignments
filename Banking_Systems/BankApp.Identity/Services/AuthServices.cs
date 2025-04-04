using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

    using BankApp.Domain;
//using BankApp.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Identity.Client;
using BankApp.Infrastrucure.Services;
using BankApp.Application.Models.Identity;
using BankApp.Application.Exception;
using System.Drawing.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Extensions.Options;

public class AuthServices:IAuthService
{
    readonly UserManager<ApplicationUser> _userManager;
    readonly SignInManager<ApplicationUser> _signInManager;
    readonly JwtSettings _jwtSettings;

public AuthServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    
    public async Task<AuthResponse> Login(AuthRequest authRequest)
    {
        var user =await _userManager.FindByEmailAsync(authRequest.Email);

        if (user == null) {
            throw new NotFoundException($"user with Email{authRequest.Email}not exist");
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);
        //here i got user with pass
        var jwtSecurityToken =await GenerateToken(user);

        var response = new AuthResponse
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        };
        return response;


    }
    public async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
      var userClaims= await _userManager.GetClaimsAsync(user);     //claim is user releted  extra information
        var roles =await _userManager.GetRolesAsync(user);  //return what is the role from role table .Get the list of role names  specified user  belomgs to . if the same user belongs to bothe admin and user   it gets i list of something
        //convert roles list into claims 
        //new Claim (clamimsType.Role,"Admin")  
        var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role,roles)).ToList();   //select role a sper list

        //Create claims  for know whom the token is given extra information
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),   //sub is nothing but username
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),  //unique identifier is jti 
            new Claim(JwtRegisteredClaimNames.Email,user.Email),  //
              new Claim("uid",user.Id),        //    wheever i decode the claim i got overall information 
                 

        }
        .Union(userClaims)
        .Union(roleClaims);
        var symmetricSecirityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var signingCredentials = new SigningCredentials(symmetricSecirityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(
                _jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
            );
        return jwtSecurityToken;

    } 



    public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
    {
        var user = new ApplicationUser
        {
            Email = registrationRequest.Email,
            FirstName = registrationRequest.FirstName,
            LastName = registrationRequest.LastName,
            UserName = registrationRequest.UserName,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(user, registrationRequest.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return new RegistrationResponse() { UserId = user.Id };

        }
        else
        {
            var errorResult = string.Join(", ", result.Errors.Select(e => e.Description));
            //var errorResult= result.Errors.Select(e => e.Description).ToList();
            throw new NotFoundException($"{errorResult}");
        }

    
}
}
   


    