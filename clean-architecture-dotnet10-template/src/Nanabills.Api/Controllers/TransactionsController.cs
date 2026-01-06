using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nanabills.Application.Transactions.Commands.CreateTransaction;
using Nanabills.Application.Transactions.Queries.GetTransaction;
using Nanabills.Application.Transactions.Queries.ListTrasactions;
using Nanabills.Contracts.Transaction;
using Nanabills.Domain.Transactions;
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

    private static Contracts.Transaction.TransactionType ToDto(DomainTransactionType transactionType)
    {
        return transactionType.Name switch
        {
            nameof(DomainTransactionType.Income) => Contracts.Transaction.TransactionType.Income,
            nameof(DomainTransactionType.Expense) => Contracts.Transaction.TransactionType.Expense,
            _ => throw new InvalidOperationException(),
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
    {
        if (!DomainTransactionType.TryFromName(
            request.TransactionType.ToString(),
            out var transactionType))
        {
            
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid transaction type");
        }

        if (!DomainTransactionStatusType.TryFromName(
            request.TransactionStatusType.ToString(),
            out var transactionStatusType))
        {

            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid transaction status type");
        }

        var command = new CreateTransactionCommand(
            new Transaction(request.UserId,
            transactionType,
            request.Amount,
            transactionStatusType,
            request.Description,
            request.CreateAt,
            request.TransactionId));

        var createTransactionResult = await _mediator.Send(command);

        return createTransactionResult.Match(
            transaction => CreatedAtAction(
                nameof(GetTransaction),
                new { transactionId = transaction.Id },
                new TransactionResponse(
                    transaction.Id,
                    ToDto(transaction.Type),
                    transaction.Amount,
                    transaction.Description,
                    ToDto(transaction.Status),
                    transaction.CreateAt)),
            Problem);
    }

    private static Contracts.Transaction.TransactionStatusType ToDto(DomainTransactionStatusType transactionStatusType)
    {
        return transactionStatusType.Name switch
        {
            nameof(DomainTransactionStatusType.Cancelled) => Contracts.Transaction.TransactionStatusType.Cancelled,
            nameof(DomainTransactionStatusType.Pending) => Contracts.Transaction.TransactionStatusType.Pending,
            nameof(DomainTransactionStatusType.Completed) => Contracts.Transaction.TransactionStatusType.Completed,
            nameof(DomainTransactionStatusType.Failed) => Contracts.Transaction.TransactionStatusType.Failed,
            _ => throw new InvalidOperationException(),
        };
    }
}
