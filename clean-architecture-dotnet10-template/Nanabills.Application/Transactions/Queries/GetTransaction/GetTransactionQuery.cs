using ErrorOr;
using MediatR;
using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Transactions.Queries.GetTransaction
{
    public record GetTransactionQuery(Guid UserId, Guid TransactionId) : IRequest<ErrorOr<Transaction>>;
}
