namespace Nanabills.Contracts.Transaction;

public record TransactionResponse(
    Guid Id,
    TransactionType Type,
    decimal Amount,
    string Description,
    TransactionStatusType Status,
    DateTime CreateAt);