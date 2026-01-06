using Microsoft.EntityFrameworkCore;
using Nanabills.Application.Common.Interfaces;
using Nanabills.Domain.Transactions;
using Nanabills.Infrastructure.Common.Persistence;

namespace Nanabills.Infrastructure.Transactions.Persistence;

public class TransactionsRepository(NanabillsDbContext dbContext) : ITransactionRepository
{
    private readonly NanabillsDbContext _dbContext = dbContext;

    public async Task<Transaction?> GetByIdAsync(Guid transactionId)
    {
        return await _dbContext.Transactions.FindAsync(transactionId);
    }

    public Task<List<Transaction>> ListByUserIdAsync(Guid userId)
    {
        return _dbContext.Transactions
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }
}
