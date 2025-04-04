using BankApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankApp.Application.Features.TransactionFeatures.Command.AddTransaction;
using BankApp.Application.Features.TransactionFeatures.Command.TransferTransaction;
using BankApp.Application.Features.TransactionFeatures.Query.GetAllTransaction;
using BankApp.Application.Features.TransactionFeatures.Query.GetTransactionByAccountId;
using BankApp.Application.Features.TransactionFeatures.Query.GetTransactionById;
using BankApp.Application.Interfaces;
using BankApp.Application.Models.Transactions;
using BankApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ITransactionRepository _transactionRepository;
        public TransactionController(IMediator mediator, ITransactionRepository transactionRepository)
        {
            _mediator = mediator;
            _transactionRepository = transactionRepository;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var allTransactions = await _mediator.Send(new GetAllTransaction());
            return Ok(allTransactions);

        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionAsync(int id, [FromBody] Addtransaction transaction)
        {
            var addTransaction = await _mediator.Send(new AddTransaction(id, transaction));
            return Ok(addTransaction);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var getById = await _mediator.Send(new GetTransactionById(id));
            return Ok(getById);
        }
        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetTransactionByAccountId(int accountId)
        {
            var getByAId = await _mediator.Send(new GetTransactionByAccountId(accountId));
            return Ok(getByAId);
        }
        [HttpPost("transfer")]

        public async Task<IActionResult> TransferAmount([FromQuery] int id, [FromBody] TransactionTransfer transferModel)
        {
            var transaction = await _mediator.Send(new TransferTransactionCommand(id, transferModel));
            return Ok(transaction);
        }

    }
}
