using ErrorOr;
using MediatR;
using Nanabills.Application.Common.Interfaces;
using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommandHandler(
    ITransactionRepository transactionsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTransactionCommand, ErrorOr<Transaction>>
{
    public readonly ITransactionRepository _transactionsRepository = transactionsRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<Transaction>> Handle(
        CreateTransactionCommand request,
        CancellationToken cancellationToken)
    {
        await _transactionsRepository.AddTransactionAsync(request.Transaction);

        await _unitOfWork.CommitChangesAsync();

        return request.Transaction;
    }
}
