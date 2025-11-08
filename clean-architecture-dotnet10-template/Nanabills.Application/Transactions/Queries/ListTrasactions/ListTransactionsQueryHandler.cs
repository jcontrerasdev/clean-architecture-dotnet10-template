using ErrorOr;
using MediatR;
using Nanabills.Application.Common.Interfaces;
using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Transactions.Queries.ListTrasactions;

public class ListTransactionsQueryHandler(
    ITransactionRepository transactionRepository,
    IUserRepository userRepository)
    : IRequestHandler<ListTransactionsQuery, ErrorOr<List<Transaction>>>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<ErrorOr<List<Transaction>>> Handle(
        ListTransactionsQuery request,
        CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsAsync(request.UserId))
        {
            return Error.NotFound(description: "User not found");
        }

        return await _transactionRepository.ListByUserIdAsync(request.UserId);
    }
}
