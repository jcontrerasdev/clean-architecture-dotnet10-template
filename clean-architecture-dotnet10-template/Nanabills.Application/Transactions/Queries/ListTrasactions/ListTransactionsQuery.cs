using MediatR;

namespace Nanabills.Application.Transactions.Queries.ListTrasactions;

public record ListTransactionsQuery(Guid UserId) : IRequest<string>;
