using System.Diagnostics.Eventing.Reader;
using BankApp.Application.Features.AccountFeature.Commands.AddAccount;
using BankApp.Application.Features.AccountFeature.Commands.DeleteAccount;
using BankApp.Application.Features.AccountFeature.Commands.UpdateCommand;
using BankApp.Application.Features.AccountFeature.Query.GetAccountById;
using BankApp.Application.Features.AccountFeature.Query.GetAccountByUserId;
using BankApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankApp.Application.Models.Accounts;
using BankApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Authorize(Roles = "User,Admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var allAccounts = await _mediator.Send(new GetAllAccountsQuery());
            return Ok(allAccounts);

        }
        [HttpPost]
        public async Task<IActionResult> AddAccountAsync([FromBody] AddAccountRequest account)
        {
            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            var addAccount = await _mediator.Send (new AddAccountCommand( user.Id,account));
            return Ok(addAccount);
        }
        
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {

            var result = await _mediator.Send(new GetAccountById(id));
            return Ok(result);
        }

        [HttpGet("ByUserId")]
        public async Task<IActionResult>GetAccountByUserId()
        {
            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            var result = await _mediator.Send(new GetAccountByUserIdCommand(user.Id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
           
            var result = await _mediator.Send(new DeleteAccount(id));
            return Ok(result);
                   }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateCommand command)
        {
            if (id != command.Id)
                return BadRequest("Account ID mismatch.");

            var updatedAccount = await _mediator.Send(command);

            return Ok(updatedAccount);
        }
    }
    }
