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
}
