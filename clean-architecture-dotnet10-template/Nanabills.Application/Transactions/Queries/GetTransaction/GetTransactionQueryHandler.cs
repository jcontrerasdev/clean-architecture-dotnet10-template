using ErrorOr;
using MediatR;
using Nanabills.Application.Common.Interfaces;
using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Transactions.Queries.GetTransaction;

public class GetTransactionQueryHandler(
    ITransactionRepository transactionRepository,
    IUserRepository userRepository) 
    : IRequestHandler<GetTransactionQuery, ErrorOr<Transaction>>
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<ErrorOr<Transaction>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsAsync(request.UserId))
        {
            return Error.NotFound(description: "User not found.");
        }

        if (await _transactionRepository.GetByIdAsync(request.TransactionId) is not Transaction transaction)
        {
            return Error.NotFound(description: "Transaction not found.");
        }

        return transaction;
    }
}
