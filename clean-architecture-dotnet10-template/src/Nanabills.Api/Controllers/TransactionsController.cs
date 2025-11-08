using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nanabills.Application.Transactions.Queries.GetTransaction;
using Nanabills.Application.Transactions.Queries.ListTrasactions;
using Nanabills.Contracts.Transaction;
namespace Nanabills.Api.Controllers;
using DomainTransactionType = Nanabills.Domain.Transactions.TransactionType;
using DomainTransactionStatusType = Nanabills.Domain.Transactions.TransactionStatusType;

[ApiController]
[Route("[controller]")]
public class TransactionsController(ISender _mediator) : ApiController
{

    [HttpGet]
    public async Task<IActionResult> ListTransactions(Guid userId)
    {
        var command = new ListTransactionsQuery(userId);

        var listTransactionsResult = await _mediator.Send(command);

        return listTransactionsResult.Match(
            transactions => Ok(transactions.ConvertAll(transaction => new TransactionResponse(
                transaction.Id,
                ToDto(transaction.Type),
                transaction.Amount,
                transaction.Description,
                ToDto(transaction.Status),
                transaction.CreateAt))),
            Problem);
    }

    [HttpGet("{transactionId:guid}")]
    public async Task<IActionResult> GetTransaction(Guid userId, Guid transactionId)
    {
        var command = new GetTransactionQuery(userId, transactionId);

        var getTransactionResult = await _mediator.Send(command);

        return getTransactionResult.Match(
            transaction => Ok(new TransactionResponse(
                transaction.Id,
                ToDto(transaction.Type),
                transaction.Amount,
                transaction.Description,
                ToDto(transaction.Status),
                transaction.CreateAt)),
            Problem);
    }

    private static TransactionType ToDto(DomainTransactionType transactionType)
    {
        return transactionType switch
        {
            DomainTransactionType.Income => TransactionType.Income,
            DomainTransactionType.Expense => TransactionType.Expense,
            _ => throw new InvalidOperationException(),
        };
    }

    private static TransactionStatusType ToDto(DomainTransactionStatusType transactionStatusType)
    {
        return transactionStatusType switch
        {
            DomainTransactionStatusType.Cancelled => TransactionStatusType.Cancelled,
            DomainTransactionStatusType.Pending => TransactionStatusType.Pending,
            DomainTransactionStatusType.Completed => TransactionStatusType.Completed,
            DomainTransactionStatusType.Failed => TransactionStatusType.Failed,
            _ => throw new InvalidOperationException(),
        };
    }
}
