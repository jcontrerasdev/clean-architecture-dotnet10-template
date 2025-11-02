using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nanabills.Application.Transactions.Queries.GetTransaction;
using Nanabills.Application.Transactions.Queries.ListTrasactions;
namespace Nanabills.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController(ISender _mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> ListTransactions(Guid userId)
    {
        var command = new ListTransactionsQuery(userId);

        string listTransactionsResult = await _mediator.Send(command);

        //var listGymsResult = await _mediator.Send(command);
        return Ok(listTransactionsResult);
    }

    [HttpGet("{transactionId:guid}")]
    public async Task<IActionResult> GetGym(Guid userId, Guid transactionId)
    {
        var command = new GetTransactionQuery(userId, transactionId);

        var getTransactionResult = await _mediator.Send(command);

        return Ok(getTransactionResult);
    }
}
