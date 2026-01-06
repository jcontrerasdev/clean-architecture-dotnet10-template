namespace Nanabills.Domain.Transactions;

public class Transaction
{
    public Guid Id { get; }
    public Guid UserId { get; set; }
    public TransactionType Type { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionStatusType Status { get; set; } = null!;
    public DateTime CreateAt { get; set; }

    private Transaction() { }

    public Transaction(
        Guid userId,
        TransactionType transactionType,
        decimal amount,
        TransactionStatusType status,
        string? description,
        DateTime? createAt,
        Guid? id)
    {
        Id = id ?? Guid.NewGuid();
        UserId = userId;
        Type = transactionType;
        Amount = amount;
        Description = description ?? string.Empty;
        Status = status;
        CreateAt = createAt ?? DateTime.UtcNow;
    }
}