namespace Nanabills.Contracts.Transaction;

public record CreateTransactionRequest(
    Guid UserId,
    TransactionType TransactionType,
    decimal Amount,
    string? Description,
    DateTime? CreateAt,
    Guid? TransactionId,
    TransactionStatusType TransactionStatusType = TransactionStatusType.Completed);
