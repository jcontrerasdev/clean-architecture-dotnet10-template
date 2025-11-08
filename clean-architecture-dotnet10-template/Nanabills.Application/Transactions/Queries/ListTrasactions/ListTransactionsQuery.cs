using ErrorOr;
using MediatR;
using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Transactions.Queries.ListTrasactions;

public record ListTransactionsQuery(Guid UserId) : IRequest<ErrorOr<List<Transaction>>>;
