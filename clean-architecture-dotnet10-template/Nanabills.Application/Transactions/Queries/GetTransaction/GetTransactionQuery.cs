using MediatR;

namespace Nanabills.Application.Transactions.Queries.GetTransaction
{
    public record GetTransactionQuery(Guid UserId, Guid TransactionId) : IRequest<string>;
}
