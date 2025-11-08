namespace Nanabills.Domain.Transactions;

public class Transaction
{
    public Guid Id { get; }
    public Guid UserId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionStatusType Status { get; set; }
    public DateTime CreateAt { get; set; }
}
