using Nanabills.Domain.Transactions;

namespace Nanabills.Application.Common.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(Guid transactionId);
    Task<List<Transaction>> ListByUserIdAsync(Guid userId);
}
