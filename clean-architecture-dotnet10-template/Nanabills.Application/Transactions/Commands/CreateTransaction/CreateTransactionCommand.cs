using ErrorOr;
using MediatR;
using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Transactions.Commands.CreateTransaction;

public record CreateTransactionCommand(Transaction Transaction)
    : IRequest<ErrorOr<Transaction>>
{
}
